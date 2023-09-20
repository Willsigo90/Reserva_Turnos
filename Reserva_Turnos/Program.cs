using BusinessLayer;
using BusinessLayer.Implementation;
using BusinessLayer.Interface;
using DataAccess;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ITurnoRepository, TurnoRepository>();
builder.Services.AddTransient<ITurnoService, TurnoService>();

// Inyectar acceso a datos
builder.Services.AddTransient<IDapperWrapper, DapperWrapper>();
builder.Services.AddTransient<IConexionFactory, ConexionFactory>();
builder.Services.AddTransient<IAccesoDatosReadOnly, AccesoDatosReadOnly>();
builder.Services.AddTransient<IAccesoDatosDataWrite, AccesoDatosDataWrite>();

builder.Services.AddControllers()
    .AddFluentValidation(config =>
    {
        config.RegisterValidatorsFromAssemblyContaining<TurnoRequestValidator>();
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
