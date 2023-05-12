using Noticias.Domain.Repository;
using Noticias.Infra.Repositories;

namespace Noticias.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IAspNetUser, AspNetUser>();

            //Repositories
            services.AddScoped<INoticiasRepository, NoticiasRepository>();


        }
    }
}