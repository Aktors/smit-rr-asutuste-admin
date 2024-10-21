using RabbitMQ.Client;

namespace asutus.api.services.rabbitMq;

//TODO: MQ related stuff to separate library
//TODO: migrate to Autofac 
public static class RabbitMqServiceCollectionExtensions
{
    //TODO: use setupAction approach
    //TODO: use some interface names that hides tech name behind implementation
    public static void AddRabbitMqConfiguration(this IServiceCollection services)
    {
        var factory = new ConnectionFactory()
        {
            HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOSTNAME") ?? "localhost",
            Port = int.Parse(Environment.GetEnvironmentVariable("RABBITMQ_PORT") ?? "5672"),
            UserName = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? "guest",
            Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? "guest"
        };
        services.AddSingleton(factory);
    }
}