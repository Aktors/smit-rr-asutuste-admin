using asutus.common.Model;
using MediatR;

namespace asutus.bl.Commands;

public class AsutusteLoeteluRequest: IRequest<QueryResultDto<AsutusShortDto>>
{
    public AsutusteQueryDto Query { get; }

    public AsutusteLoeteluRequest(AsutusteQueryDto query)
    {
        Query = query;
    }
}