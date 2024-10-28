using asutus.worker.model;

namespace asutus.worker.services;

public interface IMessageListener
{
    public event EventHandler<MessageArrivedEventArgs> MessageArrived;
    void StartListening(String queueName);
}