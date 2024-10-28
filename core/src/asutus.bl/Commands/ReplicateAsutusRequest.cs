using asutus.common.Model;
using MediatR;

namespace asutus.bl.Commands;

public class ReplicateAsutusRequest : IRequest<Unit>
{  
    public String Code { get; }
    public ReplicationDto Replication { get; }

    public ReplicateAsutusRequest(String code, ReplicationDto replications)
    {
        Code = code;
        Replication = replications;
    }
}