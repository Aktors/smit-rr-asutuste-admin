using asutus.common.Model;

namespace asutus.bl.Services;

public interface IReplicationPublisherService
{
    Task ReplicateAsync(AsutusDto asutusDto, ReplicationDto replications,
        CancellationToken cancellationToken = default);
}