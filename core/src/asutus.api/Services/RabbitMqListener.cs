using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace asutus.api.services;

public class RabbitMqListener : IMessageListener, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    private readonly  IList<string> _queueNames;
    
    public event EventHandler<MessageArrivedEventArgs>? MessageArrived;
    
    public RabbitMqListener(ConnectionFactory factory)
    {
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _queueNames = new List<string>();
    }

    public void StartListening(String queueName)
    {
        if(_queueNames.Contains(queueName))
            return;
        
        _queueNames.Add(queueName);
        
        _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received +=  (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            //TODO: add come constant that will be vilible from all places or move code to same service that will hide this detail
            // Update the message log to mark as confirmed
            if (Guid.TryParse(ea.BasicProperties.MessageId, out var referenceId))
            {
                MessageArrived?.Invoke(this,
                    new MessageArrivedEventArgs(message){ ReferenceId = referenceId });
            }
        };

        _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
    }
    
    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}

public class MessageArrivedEventArgs : EventArgs
{
    public MessageArrivedEventArgs(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
    public Guid ReferenceId { get; set; }
}