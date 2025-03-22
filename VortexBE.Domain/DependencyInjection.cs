﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VortexBE.Domain.DB;
using VortexBE.Domain.Repository;

namespace VortexBE.Domain
{
    public static class DependencyInjection
    {

        //Injection de contexto BD
        public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<VortexDB>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        //Injeccion de repositorio
        public static IServiceCollection AddCustomizedRepository(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
