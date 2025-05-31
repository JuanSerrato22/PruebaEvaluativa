using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Business.Interfaces;
using Business.Implements;
using Data.Interfaces;
using Data.Implements;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar cadena de conexión (appsettings.json debe tener "DefaultConnection")
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar ApplicationDbContext con SQL Server (o el proveedor que uses)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Registrar repositorios (Data)
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// 4. Registrar servicios (Business)
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

// 5. Registrar AutoMapper (suponiendo que tienes perfiles configurados)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 6. Agregar controladores
builder.Services.AddControllers();

// 7. Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });
});

var app = builder.Build();

// Middleware para Swagger (solo en entorno desarrollo puedes limitarlo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
        c.RoutePrefix = string.Empty; // Para que swagger esté en la raíz http://localhost:5000/
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
