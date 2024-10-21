using System.Text;
using RabbitMQ.Client;

namespace asutus.api.services;

public class RabbitMQService: IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQService(ConnectionFactory factory)
    {
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        
        _channel.QueueDeclare(
            queue:"test_queue",
            durable:false,
            exclusive:false,
            autoDelete: false,
            arguments: null);
    }

    public void SendMessage(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        
        _channel.BasicPublish(exchange:"",
            routingKey: "test_queue",
            basicProperties: null,
            body: body);
        
        Console.WriteLine(" [x] Sent {0}", message);
    }
    
    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}