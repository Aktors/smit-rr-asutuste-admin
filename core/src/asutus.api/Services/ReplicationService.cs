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

        _listener.MessageArrived += async (sender, e) => await OnMessageArrived(sender, e);
    }

    public async Task ReplicateAsync(AsutusDto asutusDto,ReplicationDto replication
        , CancellationToken cancelationToken = default)
    {
        foreach (var env in replication.Environments)
        {
            var queueName = $"{replication.Code}_{env}";
            var referenceId = await _messageLog.InitMessageAsync(
                $"{asutusDto.Code}_{queueName}", cancelationToken);
            _listener.StartListening(queueName);
            _publisher.SendMessage(queueName, asutusDto, referenceId.ToString());
        }
    }
    
    private async Task  OnMessageArrived(object? sender, MessageArrivedEventArgs e
        , CancellationToken cancelationToken = default)
    {
        await _messageLog.ConfirmMessageAsync(e.ReferenceId, e.Message, cancelationToken);
    }
}