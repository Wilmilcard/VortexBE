﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexBE.Domain.Models;

namespace VortexBE.Domain.Seed
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var fecha = DateTime.UtcNow;
            var system = "Api User";
            int id = 1;
            var faker = new Faker();
            var random = new Random();


            #region Cine
            modelBuilder.Entity<Cine>().HasData(
                new Cine { CineId = 1, Nombre = "CineColombia", Direccion = "Centro Comercial Multicentro", Ciudad = "Ibagué", CreatedAt = fecha, CreatedBy = system },
                new Cine { CineId = 2, Nombre = "Cinemark", Direccion = "Av. Siempre Viva 742", Ciudad = "Medellín", CreatedAt = fecha, CreatedBy = system },
                new Cine { CineId = 3, Nombre = "Royal Films", Direccion = "Mall Plaza", Ciudad = "Cali", CreatedAt = fecha, CreatedBy = system },
                new Cine { CineId = 4, Nombre = "Royal Films", Direccion = "Centro Comercial Unicentro", Ciudad = "Barranquilla", CreatedAt = fecha, CreatedBy = system },
                new Cine {CineId = 5, Nombre = "Cinemark", Direccion = "Plaza Central", Ciudad = "Cartagena", CreatedAt = fecha, CreatedBy = system },
                new Cine {CineId = 6, Nombre = "Multiplex Andino", Direccion = "Centro Comercial Andino", Ciudad = "Bogotá D.C.", CreatedAt = fecha, CreatedBy = system },
                new Cine {CineId = 7, Nombre = "CineColombia", Direccion = "Cra. 50 #20-30", Ciudad = "Bucaramanga", CreatedAt = fecha, CreatedBy = system },
                new Cine {CineId = 8, Nombre = "Cinemark", Direccion = "Carrera 15 #45-67", Ciudad = "Pereira", CreatedAt = fecha, CreatedBy = system },
                new Cine {CineId = 9, Nombre = "CineColombia", Direccion = "Av. 68 #22-15", Ciudad = "Manizales", CreatedAt = fecha, CreatedBy = system },
                new Cine {CineId = 10, Nombre = "Cinemark", Direccion = "Centro Comercial Ventura", Ciudad = "Cúcuta", CreatedAt = fecha, CreatedBy = system }
            );
            #endregion

            #region Salas
            id = 1;
            var capacidades = new int[] { 80, 100, 150, 200, 250 };
            var fakerSalas = new Bogus.Faker<Sala>()
                .RuleFor(x => x.SalaId, f => id++)
                .RuleFor(x => x.Numero, f => random.Next(1, 4))
                .RuleFor(x => x.Capacidad, f => capacidades[random.Next(capacidades.Length)])
                .RuleFor(x => x.CineId, f => random.Next(1, 10))
                .RuleFor(x => x.CreatedAt, f => fecha)
                .RuleFor(x => x.CreatedBy, f => system);

            var listSalas = fakerSalas.Generate(100);
            foreach (var p in listSalas)
                modelBuilder.Entity<Sala>().HasData(p);
            #endregion

            #region Peliculas
            id = 1;
            int countp = 0;

            var peliculas = new string[] { "Flow", "Superman", "Star Wars III", "Up", "Sin Limites" };
            var generos = new string[] { "Acción", "Comedia", "Drama", "Ciencia Ficción", "Terror", "Animación" };
            var clasificaciones = new string[] { "G", "PG", "PG-13", "R", "NC-17" };
            var directores = new string[] { "Steven Spielberg", "Christopher Nolan", "Quentin Tarantino", "Martin Scorsese", "Ridley Scott" };
            var posterWeb = new string[] { "https://i.imgur.com/FIF369K.png", "https://i.imgur.com/bjOqV8Q.jpeg", "https://i.imgur.com/k6ZEeAp.jpeg", "https://i.imgur.com/vZipW7h.jpeg", "https://i.imgur.com/b9MSW07.jpeg" };

            var fakerPeliculas = new Bogus.Faker<Pelicula>()
                .RuleFor(x => x.PeliculaId, f => id++)
                .RuleFor(x => x.Titulo, f => peliculas[countp++])
                .RuleFor(x => x.Descripcion, f => f.Lorem.Paragraph())
                .RuleFor(x => x.Duracion, f => random.Next(80, 180)) // Duración entre 80 y 180 min
                .RuleFor(x => x.Genero, f => generos[random.Next(generos.Length)])
                .RuleFor(x => x.Director, f => directores[random.Next(directores.Length)])
                .RuleFor(x => x.Clasificacion, f => clasificaciones[random.Next(clasificaciones.Length)])
                .RuleFor(x => x.PosterUrl, f => "URL")
                .RuleFor(x => x.FechaEstreno, f => f.Date.Between(fecha.AddYears(-5), fecha.AddMonths(6)))
                .RuleFor(x => x.Activo, f => true)
                .RuleFor(x => x.CreatedAt, f => fecha)
                .RuleFor(x => x.CreatedBy, f => system);

            var listPeliculas = fakerPeliculas.Generate(5);
            countp = 0;
            foreach (var p in listPeliculas)
            {
                p.PosterUrl = posterWeb[countp++];
                modelBuilder.Entity<Pelicula>().HasData(p);
            }
            #endregion

            #region Funcion
            id = 1;

            var precios = new int[] { 6000, 10000, 12000, 15000, 24000 };
            var fakerFunciones = new Bogus.Faker<Funcion>()
                .RuleFor(x => x.FuncionId, f => id++)
                .RuleFor(x => x.FechaHora, f => f.Date.Between(fecha, fecha.AddMonths(1)))
                .RuleFor(x => x.Precio, f => precios[random.Next(clasificaciones.Length)])
                .RuleFor(x => x.PeliculaId, f => random.Next(1, listPeliculas.Count))
                .RuleFor(x => x.SalaId, f => random.Next(1, 100))
                .RuleFor(x => x.CreatedAt, f => fecha)
                .RuleFor(x => x.CreatedBy, f => system);

            var listFunciones = fakerFunciones.Generate(150);
            foreach (var f in listFunciones)
                modelBuilder.Entity<Funcion>().HasData(f);
            #endregion

            #region Users
            id = 1;

            var fakerUser = new Bogus.Faker<User>()
                .RuleFor(x => x.UserId, f => id++)
                .RuleFor(x => x.Nombre, f => f.Name.FirstName())
                .RuleFor(x => x.Apellido, f => f.Name.LastName())
                .RuleFor(x => x.Username, (f, u) => f.Internet.UserName(u.Nombre, u.Apellido))
                .RuleFor(x => x.Telefono,  f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Email,  f => f.Internet.Email())
                .RuleFor(x => x.PasswordHash, f => Encrypt.MD5("4321"))
                .RuleFor(x => x.Activo, f => random.Next(1,10) >= 3)
                .RuleFor(x => x.CreatedAt, f => fecha)
                .RuleFor(x => x.CreatedBy, f => system)
                .RuleFor(x => x.UpdatedAt, f => random.Next(0, 2) == 1 ? fecha : (DateTime?)null);

            var listUsers = fakerUser.Generate(25);
            foreach (var u in listUsers)
                modelBuilder.Entity<User>().HasData(u);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 26,
                    Username = "vortex",
                    Nombre = "Juan David",
                    Apellido = "Leon Barrera",
                    Activo = true,
                    Email = "leonjuandavid@hotmail.com",
                    Telefono = "304 340 5607",
                    PasswordHash = Encrypt.MD5("1234"),
                    CreatedAt = fecha,
                    CreatedBy = system
                }
            );

            #endregion

            #region Entrada
            id = 1;

            var userIds = Enumerable.Range(1, 26).ToList();
            var funcionIds = Enumerable.Range(1, 100).ToList();

            var fakerEntrada = new Bogus.Faker<Entrada>()
                .RuleFor(x => x.EntradaId, f => id++)
                .RuleFor(x => x.Cantidad, f => f.Random.Int(1, 5))
                .RuleFor(x => x.Total, (f, e) => e.Cantidad * precios[random.Next(clasificaciones.Length)])
                .RuleFor(x => x.FechaCompra, f => f.Date.Past(1))
                .RuleFor(x => x.UserId, f => f.PickRandom(userIds))
                .RuleFor(x => x.FuncionId, f => f.PickRandom(funcionIds))
                .RuleFor(x => x.CreatedAt, f => fecha)
                .RuleFor(x => x.CreatedBy, f => system)
                .RuleFor(x => x.UpdatedAt, f => random.Next(0, 2) == 1 ? fecha : (DateTime?)null);

            var listEntradas = fakerEntrada.Generate(200);

            foreach (var e in listEntradas)
                modelBuilder.Entity<Entrada>().HasData(e);
            #endregion

            #region Pago
            id = 1;
            var index = 0;

            var metodosPago = new[] { "Tarjeta", "Nequi", "PSE", "Efectivo" };
            var estadosPago = new[] { "Pendiente", "Pagado", "Fallido" };

            var entradaIds = Enumerable.Range(1, 200).ToList();

            var fakerPago = new Bogus.Faker<Pago>()
                .RuleFor(x => x.PagoId, f => id++)
                .RuleFor(x => x.MetodoPago, f => f.PickRandom(metodosPago))
                .RuleFor(x => x.Estado, f => f.PickRandom(estadosPago))
                .RuleFor(x => x.FechaPago, f => f.Date.Past(1))
                .RuleFor(x => x.EntradaId, (f, i) => entradaIds[index++])
                .RuleFor(x => x.CreatedAt, f => fecha)
                .RuleFor(x => x.CreatedBy, f => system)
                .RuleFor(x => x.UpdatedAt, f => random.Next(0, 2) == 1 ? fecha : (DateTime?)null);

            var listPagos = fakerPago.Generate(200);

            foreach (var p in listPagos)
                modelBuilder.Entity<Pago>().HasData(p);
            #endregion
        }
    }
}
