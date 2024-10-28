using asutus.bl.Services;
using asutus.common.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace asutus.bl.Extensions;

public static class RabbitMqServiceCollectionExtensions
{
    public static void AddRabbitMqFactory(this IServiceCollection services,
        RabbitMqOptions rabbitMqOptions,
        Action<ConnectionFactory> setupAction)
    {
        var factory = new ConnectionFactory
        {
            HostName = rabbitMqOptions.HostName,
            Port = rabbitMqOptions.Port,
            UserName = rabbitMqOptions.UserName,
            Password = rabbitMqOptions.Password,
            VirtualHost = rabbitMqOptions.VirtualHost
        };
        
        setupAction?.Invoke(factory);
        services.AddSingleton(factory);
    }
}