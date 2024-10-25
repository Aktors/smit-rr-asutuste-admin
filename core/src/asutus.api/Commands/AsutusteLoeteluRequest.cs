using asutus.api.Model;
using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class AsutusteLoeteluRequest: IRequest<QueryResultDto<AsutusShortDto>>
{
    public AsutusteQuery Query { get; }

    public AsutusteLoeteluRequest(AsutusteQuery query)
    {
        Query = query;
    }
}