using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VigilyAPI.Context;
using VigilyAPI.Extensions;
using VigilyAPI.Filters;
using VigilyAPI.Interfaces;
using VigilyAPI.Models;
using VigilyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder
    .Services.AddControllers(x =>
    {
        x.Filters.Add(typeof(ApiExceptionFilter));
    })
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<VigilyAPI.Services.EmpresaService>();
builder.Services.AddScoped<VigilanteService>();
builder.Services.AddScoped<ApiLogginFilter>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddDbContext<VigilyAPICon>(o =>
{
    o.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
});

builder.Services.AddTransient<IMeuService, MeuServico>();
builder.Services.AddTransient<IEmpresaService, IEmpresaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
