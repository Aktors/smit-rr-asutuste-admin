using asutus.common.Model;

namespace asutus.api.services;

public interface IReplicationService
{
    Task Replicate(AsutusDto asutusDto, ReplicationDto[] replications);
}