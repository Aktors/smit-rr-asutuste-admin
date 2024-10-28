using asutus.bl.Services;
using asutus.domain.Data;
using asutus.domain.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;

namespace asutus.api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Asutus API",
                Version = "v1",
                Description = "API for managing Asutus records",
                Contact = new OpenApiContact
                {
                    Name = "Stan Virk",
                    Email = "stan.virk@aktors.ee",
                    Url = new Uri("https://aktors.ee/")
                }
            });
            c.EnableAnnotations();
        });
    }

    public static void AllowCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }
    
    public static void AddRabbitMqPublisher(this IServiceCollection services)
    {
        services.AddScoped<IReplicationPublisherService, ReplicationPublisherService>();
        services.AddScoped<IMessagePublisherService, RabbitMqPublisherService>();
        services.AddScoped<IMessageLogService, DbMessageLogService>();
    }
    
    public static void AddPostgresDbStorageImplementation(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AsutusContext>(options => {
            options.UseNpgsql(builder.Configuration.GetConnectionString("AsutusConnection"));
        });
        builder.Services.AddScoped<IMessageLogRepository, MessageLogRepository>();
        builder.Services.AddScoped<IAsutusRepository, AsutusRepository>();
        builder.Services.AddScoped<IInformationSystemRepository, InformationSystemRepository>();
    }
}