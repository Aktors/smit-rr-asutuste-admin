using asutus.common.Model;

namespace asutus.bl.Services;

public class ReplicationPublisherService : IReplicationPublisherService
{
    private readonly IMessageLogService _messageLog;
    private readonly IMessagePublisherService _publisher;
    
    public ReplicationPublisherService(
        IMessageLogService messageLog,
        IMessagePublisherService publisher)
    {
        _messageLog = messageLog;
        _publisher = publisher;
    }

    public async Task ReplicateAsync(AsutusDto asutusDto,ReplicationDto replication
        , CancellationToken cancelationToken = default)
    {
        foreach (var env in replication.Environments)
        {
            var queueName = $"{replication.Code}_{env}";
            var referenceId = await _messageLog.InitMessageAsync(
                $"{asutusDto.Code}_{queueName}", cancelationToken);
            _publisher.SendMessage(queueName, asutusDto, referenceId.ToString());
        }
    }
}