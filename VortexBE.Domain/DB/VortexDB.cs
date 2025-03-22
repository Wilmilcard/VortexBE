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
