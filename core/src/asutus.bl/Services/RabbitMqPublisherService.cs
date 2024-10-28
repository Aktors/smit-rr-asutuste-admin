using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace asutus.bl.Services;

public class RabbitMqPublisherService: IMessagePublisherService, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    public RabbitMqPublisherService(
        ConnectionFactory factory)
    {
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void SendMessage<T>(String queueName,T payload, string messageId)
    {
        _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        
        var properties = _channel.CreateBasicProperties();
        properties.Persistent = true;
        properties.MessageId = messageId;
        
        var messageBody = JsonSerializer.Serialize(payload);
        var body = Encoding.UTF8.GetBytes(messageBody);

        _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: properties, body: body);
    }
    
    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}