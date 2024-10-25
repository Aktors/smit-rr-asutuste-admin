using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class ReplicationLogQueryCommand: IRequest<QueryResultDto<ReplicationLogDto>>
{
    public ReplicationLogQueryDto Query { get; }

    public ReplicationLogQueryCommand(ReplicationLogQueryDto query)
    {
        Query = query;
    }
}