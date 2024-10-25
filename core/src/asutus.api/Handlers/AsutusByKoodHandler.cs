using asutus.api.Commands;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class AsutusByKoodHandler:  IRequestHandler<AsutusByKoodCommand, AsutusDto?>
{    
    private readonly IAsutusRepository _asutusRepository;

    public AsutusByKoodHandler(IAsutusRepository asutusRepository)
    {
        _asutusRepository = asutusRepository;
    }

    public async Task<AsutusDto?> Handle(AsutusByKoodCommand command, CancellationToken cancellationToken)
    {
        return await _asutusRepository.GetAsutusAsync(command.Code);
    }
}