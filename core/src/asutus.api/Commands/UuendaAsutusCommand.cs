using asutus.common.Model;
using MediatR;

namespace asutus.api.Commands;

public class UuendaAsutusCommand : IRequest<Unit>
{
    public AsutusDto Asutus { get; }
    
    public UuendaAsutusCommand(AsutusDto asutus)
    {
        Asutus = asutus;
    }
}