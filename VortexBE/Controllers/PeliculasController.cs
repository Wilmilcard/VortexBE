using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Reflection;
using VortexBE.Domain;
using VortexBE.Domain.DB;
using VortexBE.Domain.Models;
using VortexBE.HttpRequest;
using VortexBE.Interfaces;
using VortexBE.Services;
using VortexBE.Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace VortexBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly VortexDB _context;
        private readonly IPeliculaServices _peliculaServices;
        private readonly IConfiguration _configuration;

        public PeliculasController(VortexDB context, IPeliculaServices peliculaServices, IConfiguration configuration)
        {
            _context = context;
            _peliculaServices = peliculaServices;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet("[Action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var images_web = _configuration["CustomPaths:images_web"];
                var images_local = Globals.PathSystem(["VortexBE.Domain", "Assets"]);

                var query = _peliculaServices
                    .QueryNoTracking()
                    .Include(x => x.Funciones)
                        .ThenInclude(s => s.Sala)
                            .ThenInclude(c => c.Cine)
                    .Select(x => new
                    {
                        x.PeliculaId,
                        x.Titulo,
                        x.Descripcion,
                        x.Duracion,
                        x.Genero,
                        x.Director,
                        x.Clasificacion,
                        poster_web = $"{images_web}",
                        poster_local = $"{images_local}\\{x.PosterUrl}",
                        x.FechaEstreno,
                        x.Activo,
                        Funciones = x.Funciones
                            .Where(f => f.PeliculaId == x.PeliculaId)
                            .Select(f => new
                            {
                                Sala = f.Sala.Numero,
                                Cine = f.Sala.Cine.Nombre,
                                f.FechaHora,
                                f.Precio
                            })
                            .ToList()
                    })
                    .ToList();

                var response = new
                {
                    success = true,
                    data = query,
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    success = false,
                    error = ex.Message,
                    errorCode = ex.HResult
                };
                return new BadRequestObjectResult(response);

            }
            
        }

        [AllowAnonymous]
        [HttpGet("[Action]/{cineId}")]
        public async Task<IActionResult> GetByCine([FromRoute] int cineId)
        {
            try
            {
                var images_web = _configuration["CustomPaths:images_web"];
                var images_local = Globals.PathSystem(["VortexBE.Domain", "Assets"]);

                var query = _context.funciones
                    .Include(x => x.Sala)
                        .ThenInclude(c => c.Cine)
                    .Include(x => x.Pelicula)
                    .Where(x => x.Sala.CineId == cineId)
                    .Select(x => new
                    {
                        x.FuncionId,
                        x.Sala.Cine.Nombre,
                        x.Sala.Cine.Direccion,
                        x.Pelicula.Titulo,
                        x.FechaHora,
                        x.Precio
                    })
                    .ToList();

                var response = new
                {
                    success = true,
                    data = query,
                };

                return new OkObjectResult(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    success = false,
                    error = ex.Message,
                    errorCode = ex.HResult
                };
                return new BadRequestObjectResult(response);

            }

        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Create([FromBody] PeliculaCreateUpdate request)
        {
            //No se usa Try Catch pues ya lo tengo de manera Global
            using (var transaccion = _context.Database.BeginTransaction())
            {
                var claims = User.Claims.FirstOrDefault();
                var user = _context.usuarios.Where(x => x.Username == claims.Value).FirstOrDefault();

                if (request == null)
                    return BadRequest(new { success = false, error = 400, content = "La informacion que envio esta vacia" });

                Pelicula p = new Pelicula
                {
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    Duracion = request.Duracion,
                    Genero = request.Genero,
                    Director = request.Director,
                    Clasificacion = request.Clasificacion,
                    PosterUrl = request.PosterUrl,
                    FechaEstreno = request.FechaEstreno,
                    Activo = true,
                    CreatedAt = Globals.SystemDate(),
                    CreatedBy = user.Username
                };

                await _peliculaServices.AddAsync(p);
                _context.SaveChanges();
                transaccion.Commit();
            }

            var response = new
            {
                success = true,
                data = request
            };

            return new OkObjectResult(response);

        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Update([FromBody] PeliculaCreateUpdate request)
        {
            //No se usa Try Catch pues ya lo tengo de manera Global
            using (var transaccion = _context.Database.BeginTransaction())
            {
                var claims = User.Claims.FirstOrDefault();
                var user = _context.usuarios.Where(x => x.Username == claims.Value).FirstOrDefault();

                if (request == null)
                    return BadRequest(new { success = false, error = 400, content = "La informacion que envio esta vacia" });

                var pelicula = this._peliculaServices.QueryNoTracking().Where(x => x.PeliculaId == request.PeliculaId).FirstOrDefault();

                pelicula.Titulo = request.Titulo;
                pelicula.Descripcion = request.Descripcion;
                pelicula.Duracion = request.Duracion;
                pelicula.Genero = request.Genero;
                pelicula.Director = request.Director;
                pelicula.Clasificacion = request.Clasificacion;
                pelicula.PosterUrl = request.PosterUrl;
                pelicula.FechaEstreno = request.FechaEstreno;
                pelicula.UpdatedAt = Globals.SystemDate();
                pelicula.CreatedBy = user.Username;

                await _peliculaServices.UpdateAsync(pelicula);
                _context.SaveChanges();
                transaccion.Commit();
            }

            var response = new
            {
                success = true,
                data = request
            };

            return new OkObjectResult(response);

        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Enable([FromBody] PeliculaCreateUpdate request)
        {
            //No se usa Try Catch pues ya lo tengo de manera Global
            using (var transaccion = _context.Database.BeginTransaction())
            {
                var claims = User.Claims.FirstOrDefault();
                var user = _context.usuarios.Where(x => x.Username == claims.Value).FirstOrDefault();

                if (request == null)
                    return BadRequest(new { success = false, error = 400, content = "La informacion que envio esta vacia" });

                var pelicula = this._peliculaServices.QueryNoTracking().Where(x => x.PeliculaId == request.PeliculaId).FirstOrDefault();

                pelicula.Activo = request.Activo;
                pelicula.UpdatedAt = Globals.SystemDate();
                pelicula.CreatedBy = user.Username;

                await _peliculaServices.UpdateAsync(pelicula);
                _context.SaveChanges();
                transaccion.Commit();
            }

            var response = new
            {
                success = true,
                data = request
            };

            return new OkObjectResult(response);

        }
    }
}
