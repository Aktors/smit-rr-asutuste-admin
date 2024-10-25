using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class UuendaAsutusRequest : IRequest<Unit>
{
    public AsutusDto Asutus { get; }
    
    public UuendaAsutusRequest(AsutusDto asutus)
    {
        Asutus = asutus;
    }
}