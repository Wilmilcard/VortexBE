using VortexBE.Interfaces;
using VortexBE.Services;

namespace VortexBE
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomizedServicesProject(this IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IPeliculaServices, PeliculaServices>();
            services.AddScoped<IEntradaServices, EntradaServices>();

            return services;
        }
    }
}
