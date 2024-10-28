namespace asutus.bl.Services;

public interface IMessagePublisherService
{
    void SendMessage<T>(String queueName, T payload, string messageId);
}