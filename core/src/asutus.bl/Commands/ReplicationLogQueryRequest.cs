using asutus.common.Model;
using MediatR;

namespace asutus.bl.Commands;

public class ReplicationLogQueryRequest: IRequest<QueryResultDto<ReplicationLogDto>>
{
    public ReplicationLogQueryDto Query { get; }

    public ReplicationLogQueryRequest(ReplicationLogQueryDto query)
    {
        Query = query;
    }
}