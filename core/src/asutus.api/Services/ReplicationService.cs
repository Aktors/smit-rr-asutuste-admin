using asutus.common.Model;

namespace asutus.api.services;

public class ReplicationService : IReplicationService
{
    private readonly IMessageLogService _messageLog;
    private readonly IMessagePublisherService _publisher;
    private readonly IMessageListener _listener;
    
    public ReplicationService(
        IMessageLogService messageLog,
        IMessagePublisherService publisher,
        IMessageListener listener)
    {
        _messageLog = messageLog;
        _publisher = publisher;
        _listener = listener;

        _listener.MessageArrived += OnMessageArrived;
    }

    public async Task Replicate(AsutusDto asutusDto,ReplicationDto[] replications)
    {
        foreach (var rep in replications)
            foreach (var env in rep.Enviroments)
                {
                    var queueName = $"{rep.Code}_{env}";
                    var referenceId = await _messageLog.InitMessage($"{asutusDto.Code}_{queueName}");
                    _listener.StartListening(queueName);
                    _publisher.SendMessage(queueName, asutusDto, referenceId.ToString());
                }
    }
    
    private void OnMessageArrived(object? sender, MessageArrivedEventArgs e)
    {
        _messageLog.ConfirmMessageAsync(e.ReferenceId, e.Message);
    }
}