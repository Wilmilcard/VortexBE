using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexBE.Domain.Models;
using VortexBE.Domain.Seed;

namespace VortexBE.Domain.DB
{
    public class VortexDB : DbContext
    {
        public VortexDB(DbContextOptions<VortexDB> options) : base(options)
        {

        }

        public DbSet<Cine> cines { get; set; }
        public DbSet<Entrada> entradas { get; set; }
        public DbSet<Funcion> funciones { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<Pelicula> peliculas { get; set; }
        public DbSet<Sala> salas { get; set; }
        public DbSet<User> usuarios { get; set; }
        public DbSet<Sesion> sesiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings
                    .Log(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
