using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class ReplicateAsutusCommand : IRequest<Unit>
{  
    public ReplicationDto Replication { get; }

    public ReplicateAsutusCommand(ReplicationDto replications)
    {
        Replication = replications;
    }
}