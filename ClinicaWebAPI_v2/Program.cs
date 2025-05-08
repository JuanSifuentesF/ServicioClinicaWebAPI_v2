using ClinicaWebAPI_v2.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Recuperar la cadena de conexion del appsettings.json
var cadena = builder.Configuration.GetConnectionString("cn1");

// Registrar el archivo del contexto de la BD y que esta utilice la cadena de conexion
builder.Services.AddDbContext<Bdclinica2022Context>(options =>
    options.UseSqlServer(cadena));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
