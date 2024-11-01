﻿using System.Text;
using asutus.bl.Services;
using asutus.worker.model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace asutus.worker.services;

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
            if (Guid.TryParse(ea.BasicProperties.MessageId, out var referenceId))
                MessageArrived?.Invoke(this,
                    new MessageArrivedEventArgs(message){ ReferenceId = referenceId });
        };

        _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
    }
    
    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}