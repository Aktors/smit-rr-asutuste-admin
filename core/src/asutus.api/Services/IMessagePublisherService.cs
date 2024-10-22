namespace asutus.api.services;

public interface IMessagePublisherService
{
    void SendMessage<T>(String queueName, T payload, string messageId);
}