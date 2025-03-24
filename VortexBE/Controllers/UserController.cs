using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VortexBE.Domain;
using VortexBE.Domain.DB;
using VortexBE.Domain.Models;
using VortexBE.HttpRequest;
using VortexBE.Interfaces;
using VortexBE.Services;
using VortexBE.Utils;

namespace VortexBE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly VortexDB _context;
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;

        public UserController(VortexDB context, IUserServices userServices, IConfiguration configuration)
        {
            _context = context;
            _userServices = userServices;
            _configuration = configuration;
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAll()
        {
            var query = _userServices
                .QueryNoTracking()
                .Select(x => new
                {
                    x.UserId,
                    x.Nombre,
                    x.Apellido,
                    x.Email,
                    x.Telefono,
                    x.Activo
                })
                .ToList();

            var response = new
            {
                succcess = true,
                data = query
            };

            return new OkObjectResult(response);
        }

        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {
            var query = _userServices
                .QueryNoTracking()
                .Select(x => new
                {
                    x.UserId,
                    x.Nombre,
                    x.Apellido,
                    x.Email,
                    x.Telefono,
                    x.Activo
                })
                .Where(x => x.UserId == userId)
                .FirstOrDefault();

            var response = new
            {
                succcess = true,
                data = query
            };

            return new OkObjectResult(response);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromBody] UserCreateUpdate request)
        {
            //No se usa Try Catch pues ya lo tengo de manera Global
            using (var transaccion = _context.Database.BeginTransaction())
            {
                var claims = User.Claims.FirstOrDefault();
                var user = _context.usuarios.Where(x => x.Username == claims.Value).FirstOrDefault();

                var exists_mail = _userServices.QueryNoTracking().Where(x => x.Email == request.Email).FirstOrDefault();

                if(exists_mail != null)
                    return new BadRequestObjectResult(new { success = false, data = "El email que intenta registrar ya existe" });
                
                var newUser = new User
                {
                    Username = request.Username,
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    PasswordHash = Encrypt.MD5(request.Password),
                    CreatedAt = Globals.SystemDate(),
                    CreatedBy = user.Username
                };

                await _userServices.AddAsync(newUser);

                transaccion.Commit();
            }

            var response = new
            {
                succcess = true,
                data = "Proceso terminado"
            };

            return new OkObjectResult(response);
        }

        [HttpPut("[Action]")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStateRequest request)
        {
            //No se usa Try Catch pues ya lo tengo de manera Global
            using (var transaccion = _context.Database.BeginTransaction())
            {
                var claims = User.Claims.FirstOrDefault();
                var user = _context.usuarios.Where(x => x.Username == claims.Value).FirstOrDefault();

                var _user = _userServices.QueryNoTracking().Where(x => x.UserId == request.Id).FirstOrDefault();
                
                _user.Activo = request.Estado;
                _user.UpdatedAt = Globals.SystemDate();
                _user.CreatedBy = user.Username;

                await _userServices.UpdateAsync(_user);

                transaccion.Commit();
            }

            var response = new
            {
                succcess = true,
                data = "Usuario actualizado"
            };

            return new OkObjectResult(response);
        }
    }
}
