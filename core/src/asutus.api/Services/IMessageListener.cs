namespace asutus.api.services;

public interface IMessageListener
{
    public event EventHandler<MessageArrivedEventArgs> MessageArrived;
    void StartListening(String queueName);
}