using asutus.api.Model;
using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class AsutusteLoeteluCommand: IRequest<QueryResultDto<AsutusShortDto>>
{
    public AsutusteQuery Query { get; }

    public AsutusteLoeteluCommand(AsutusteQuery query)
    {
        Query = query;
    }
}