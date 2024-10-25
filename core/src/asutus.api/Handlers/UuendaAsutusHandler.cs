using asutus.api.Commands;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class UuendaAsutusHandler: IRequestHandler<UuendaAsutusCommand,Unit>
{
    private readonly IAsutusRepository _asutusRepository;

    public UuendaAsutusHandler(IAsutusRepository asutusRepository)
    {
        _asutusRepository = asutusRepository;
    }

    public async Task<Unit> Handle(UuendaAsutusCommand request, CancellationToken cancellationToken)
    {
        await _asutusRepository.AddOrUpdateAsync(request.Asutus);
        return Unit.Value;
    }
}