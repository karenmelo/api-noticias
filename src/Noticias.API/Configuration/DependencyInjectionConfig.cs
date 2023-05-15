using Microsoft.EntityFrameworkCore;
using SistemaNoticias.API.Extensions;
using SistemaNoticias.Domain.Interfaces;
using SistemaNoticias.Domain.Repository;
using SistemaNoticias.Infra.Data;
using SistemaNoticias.Infra.Repositories;

namespace SistemaNoticias.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Infra
            services.AddDbContext<NoticiasContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUsuario, AspNetUsuario>();

            //Repositories
            services.AddScoped<INoticiasRepository, NoticiasRepository>();
            services.AddScoped<IClassificacaoNoticiasRepository, ClassificacaoNoticiasRepository>();


        }
    }
}