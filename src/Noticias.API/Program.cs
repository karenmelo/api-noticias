using Noticias.API.Configuration;
using SistemaNoticias.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAuthConfiguration(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
