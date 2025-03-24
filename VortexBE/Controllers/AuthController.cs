using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VortexBE.Domain.Models;
using VortexBE.Domain;
using VortexBE.Utils;
using VortexBE.HttpRequest;
using VortexBE.Domain.DB;
using VortexBE.Services;

namespace VortexBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly VortexDB _context;
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public AuthController(VortexDB context, IUserServices userServices, IConfiguration configuration)
        {
            _context = context;
            _userServices = userServices;
            _configuration = configuration;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Catch errors are caught by the GlobalExceptionHandler class

            if (string.IsNullOrEmpty(request.username) || string.IsNullOrEmpty(request.password))
                return new BadRequestObjectResult(new { success = false, data = "El usuario y/o contraseña estan vacios" });

            var user = _userServices.QueryNoTracking().Where(x => x.Username == request.username).FirstOrDefault();
            if (user == null)
                return new BadRequestObjectResult(new { success = false, data = "El usuario no se encuentra registrado" });

            var pass = Encrypt.MD5(request.password);

            //Token Time
            var expiration_date = Globals.SystemDate().AddHours(5).AddHours(8);//8 hours of life for the token

            var jwtHelper = new JWTHelper(this._configuration.GetValue<string>("SecurityKey"));
            var token = jwtHelper.CreateToken(request.username, expiration_date);

            //validate the session
            var _sesion = _context.sesiones
                .Where(x => x.UserId == user.UserId)
                .FirstOrDefault();

            if (_sesion == null)
            {
                var sesion = new Sesion
                {
                    UserId = user.UserId,
                    Token = token,
                    Expiration_Date = expiration_date,
                    CreatedAt = Globals.SystemDate(),
                    CreatedBy = Globals.SystemUser()
                };
                _context.sesiones.Add(sesion);

                _sesion = _context.sesiones.Where(x => x.UserId == user.UserId).FirstOrDefault();
            }
            else
            {
                _sesion.Token = token;
                _sesion.Expiration_Date = expiration_date;
                _sesion.UpdatedAt = Globals.SystemDate();
                _sesion.CreatedBy = Globals.SystemUser();
                _context.sesiones.Update(_sesion);
            }

            user.UpdatedAt = Globals.SystemDate();
            _context.usuarios.Update(user);

            _context.SaveChanges();

            var response = new
            {
                success = true,
                data = new
                {
                    _sesion.User.Username,
                    token
                },
            };

            return new OkObjectResult(response);
        }

        
    }
}
