using backend.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.HttpsPolicy;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Aggiungi servizi al container di dependency injection.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
        });

        builder.Services.AddScoped<IServiceResponse, ServiceResponse>();

        // Aggiungi AutoMapper e registra il profilo di mappatura
        builder.Services.AddAutoMapper(typeof(Program).Assembly);  // Assicurati di importare AutoMapper qui

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1");
            });
        }

        app.UseHttpsRedirection();
     
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}