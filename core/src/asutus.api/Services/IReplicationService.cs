using asutus.common.Model;

namespace asutus.api.services;

public interface IReplicationService
{
    Task ReplicateAsync(AsutusDto asutusDto, ReplicationDto replications,
        CancellationToken cancellationToken = default);
}