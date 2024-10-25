using asutus.api.services;
using asutus.api.services.rabbitMq;
using asutus.domain.Data;
using asutus.domain.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

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
            //TODO: configuring env properly
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }

    public static void AddRabbitMqImplementation(this IServiceCollection services)
    {
        services.AddRabbitMqConfiguration();
        services.AddScoped<IReplicationService, ReplicationService>();
        services.AddScoped<IMessagePublisherService, RabbitMqPublisherService>();
        services.AddScoped<IMessageListener, RabbitMqListener>();
        services.AddScoped<IMessageLogService, DbMessageLogService>();
    }

    public static void AddPostgresDbStorageImplementation(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AsutusContext>(options => {
            options.UseNpgsql(builder.Configuration.GetConnectionString("AsutusConnection"));
        });
        builder.Services.AddScoped<IMessageLogRepository, DbMessageLogRepository>();
        builder.Services.AddScoped<IAsutusRepository, DbAsutusRepository>();
    }
}