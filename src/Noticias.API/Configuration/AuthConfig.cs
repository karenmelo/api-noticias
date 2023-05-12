namespace Noticias.API.Configuration
{
    public static class AuthConfig
    {

        //public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //    // Configuração do JWT
        //    var key = Encoding.ASCII.GetBytes("chave_secreta_aqui");

        //    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //        .AddJwtBearer(options =>
        //        {
        //            options.RequireHttpsMetadata = false;
        //            options.SaveToken = true;
        //            options.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuerSigningKey = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(key),
        //                ValidateIssuer = false,
        //                ValidateAudience = false
        //            };
        //        });

        //    services.AddControllers();
        //}

    }
}
