using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PagosController : ControllerBase
    {
        private readonly VortexDB _context;
        private readonly IEntradaServices _entradaServices;
        private readonly IConfiguration _configuration;

        public PagosController(VortexDB context, IEntradaServices entradaServices, IConfiguration configuration)
        {
            _context = context;
            _entradaServices = entradaServices;
            _configuration = configuration;
        }

        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var query = _entradaServices
                .QueryNoTracking()
                .Include(x => x.Pago)
                .Include(x => x.Usuario)
                .Include(x => x.Funcion)
                    .ThenInclude(s => s.Sala)
                        .ThenInclude(c => c.Cine)
                .Include(x => x.Funcion)
                    .ThenInclude(s => s.Pelicula)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.Pago.FechaPago)
                .ToList();

            var data_response = new
            {
                Nombre = $"{query[0].Usuario.Nombre} {query[0].Usuario.Apellido}",
                query[0].Usuario.Email,
                query[0].Usuario.Username,
                query[0].Usuario.Telefono,
                compras = query.Select(x => new
                        {
                            x.Funcion.Pelicula.Titulo,
                            Cine = x.Funcion.Sala.Cine.Nombre,
                            x.Funcion.Sala.Cine.Ciudad,
                            x.Funcion.Sala.Cine.Direccion,
                            x.FechaCompra,
                            x.Cantidad,
                            x.Pago.PagoId,
                            x.Pago.FechaPago,
                            x.Pago.MetodoPago,
                            x.Total,
                            x.Pago.Estado
                        }).ToList()
            };

            var response = new
            {
                succcess = true,
                data = data_response
            };

            return new OkObjectResult(response);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Pay([FromBody] PagoRequest request)
        {
            using (var transaccion = _context.Database.BeginTransaction())
            {
                var claims = User.Claims.FirstOrDefault();
                var user = _context.usuarios.Where(x => x.Username == claims.Value).FirstOrDefault();

                if(user == null)
                    return BadRequest(new { success = false, error = 400, content = "No se encuentra registrado" });

                var nuevaEntrada = new Entrada
                {
                    UserId = user.UserId,
                    Cantidad = request.Cantidad,
                    FechaCompra = Globals.SystemDate(),
                    FuncionId = request.FuncionId,
                    Total = request.Cantidad * request.Total,
                    CreatedAt = Globals.SystemDate(),
                    CreatedBy = user.Username
                };

                await _entradaServices.AddAsync(nuevaEntrada);

                Random random = new Random();

                var estadosPago = new[] { "Pendiente", "Pagado", "Fallido" };
                
                var nuevoPago = new Pago
                {
                    FechaPago = Globals.SystemDate().AddSeconds(4),
                    EntradaId = nuevaEntrada.EntradaId,
                    MetodoPago = request.MetodoPago,
                    Estado = estadosPago[random.Next(estadosPago.Length)],
                    CreatedAt = Globals.SystemDate(),
                    CreatedBy = user.Username
                };

                await _context.pagos.AddAsync(nuevoPago);
                _context.SaveChanges();

                var funcion = _context.funciones
                    .Include(x => x.Pelicula)
                    .Include(x => x.Sala)
                        .ThenInclude(c => c.Cine)
                    .Where(x => x.FuncionId == nuevaEntrada.FuncionId)
                    .FirstOrDefault();

                var email = new EmailTools();
                await email.SendEmailAsync(user, nuevoPago, nuevaEntrada, funcion, "Confirmación Pago");

                transaccion.Commit();
            }

            var response = new
            {
                succcess = true,
                data = "OK Mensaje"
            };

            return new OkObjectResult(response);
        }
    }
}
