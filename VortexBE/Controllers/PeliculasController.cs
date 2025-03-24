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

        [AllowAnonymous]
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
        [HttpPost("[Action]")]
        public async Task<IActionResult> GetByFilters([FromBody] FilterMoviesRequest request)
        {
            try
            {
                var images_web = _configuration["CustomPaths:images_web"];
                var images_local = Globals.PathSystem(["VortexBE.Domain", "Assets"]);

                var query = _context.funciones
                    .Include(x => x.Sala)
                        .ThenInclude(c => c.Cine)
                    .Include(x => x.Pelicula)
                    .ToList();

                if (request.CineId != null || request.CineId > 0)
                    query = query.Where(x => x.Sala.CineId == request.CineId).ToList();
                if (request.DireccionCine != null)
                    query = query.Where(x => x.Sala.Cine.Direccion.Contains(request.DireccionCine)).ToList();
                if (request.Titulo != null)
                    query = query.Where(x => x.Pelicula.Titulo.Contains(request.Titulo)).ToList();
                if (request.Descripcion != null)
                    query = query.Where(x => x.Pelicula.Descripcion.Contains(request.Descripcion)).ToList();
                if (request.Genero != null)
                    query = query.Where(x => x.Pelicula.Genero.Contains(request.Genero)).ToList();
                if (request.Director != null)
                    query = query.Where(x => x.Pelicula.Director.Contains(request.Director)).ToList();
                
                
                if (request.FechaFuncionInicio > request.FechaFuncionFin)
                    return BadRequest(new { success = false, error = 400, content = "La fecha fin es anterior a la fecha inicio" });
                if (request.FechaFuncionInicio == null && request.FechaFuncionFin != null)
                    return BadRequest(new { success = false, error = 400, content = "La fecha inicio esta null" });
                if (request.FechaFuncionInicio != null && request.FechaFuncionFin == null)
                    return BadRequest(new { success = false, error = 400, content = "La fecha fin esta null" });
                if (request.FechaFuncionInicio != null && request.FechaFuncionFin != null)
                    query = query.Where(x => x.FechaHora >= request.FechaFuncionInicio && x.FechaHora <= request.FechaFuncionFin).ToList();


                var response = new
                {
                    success = true,
                    data = query
                        .Select(x => new
                        {
                            x.Pelicula.Titulo,
                            x.Sala.Cine.Nombre,
                            x.Sala.Cine.Direccion,
                            x.FechaHora,
                            x.Precio
                        }).ToList()
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

        [Authorize]
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

                var funciones = _context.funciones.Where(x => request.FuncionesId.Contains(x.FuncionId)).ToList();
                foreach(var f in funciones)
                {
                    f.PeliculaId = p.PeliculaId;
                    f.UpdatedAt = Globals.SystemDate();
                    f.CreatedBy = user.Username;

                    _context.funciones.Update(f);
                }

                _context.SaveChanges();
                transaccion.Commit();
            }

            var response = new
            {
                success = true,
                data = $"Pelicula {request.Titulo} creada"
            };

            return new OkObjectResult(response);

        }

        [Authorize]
        [HttpPut("[Action]")]
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

                var funciones = _context.funciones.Where(x => request.FuncionesId.Contains(x.FuncionId)).ToList();
                foreach (var f in funciones)
                {
                    f.PeliculaId = pelicula.PeliculaId;
                    f.UpdatedAt = Globals.SystemDate();
                    f.CreatedBy = user.Username;

                    _context.funciones.Update(f);
                }

                _context.SaveChanges();
                transaccion.Commit();
            }

            var response = new
            {
                success = true,
                data = $"Pelicula {request.Titulo} actualizada"
            };

            return new OkObjectResult(response);

        }

        [Authorize]
        [HttpPut("[Action]")]
        public async Task<IActionResult> ChangeState([FromBody] EnableRequest request)
        {
            //No se usa Try Catch pues ya lo tengo de manera Global
            using (var transaccion = _context.Database.BeginTransaction())
            {
                var claims = User.Claims.FirstOrDefault();
                var user = _context.usuarios.Where(x => x.Username == claims.Value).FirstOrDefault();

                if (request == null)
                    return BadRequest(new { success = false, error = 400, content = "La informacion que envio esta vacia" });

                var pelicula = this._peliculaServices.QueryNoTracking().Where(x => x.PeliculaId == request.Id).FirstOrDefault();

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
                data = $"Pelicula se le cambio el estado a {request.Activo}"
            };

            return new OkObjectResult(response);

        }
    }
}
