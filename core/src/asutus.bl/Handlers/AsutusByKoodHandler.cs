using asutus.bl.Commands;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.bl.Handlers;

public class AsutusByKoodHandler:  IRequestHandler<AsutusByKoodRequest, AsutusDto?>
{    
    private readonly IAsutusRepository _asutusRepository;

    public AsutusByKoodHandler(IAsutusRepository asutusRepository)
    {
        _asutusRepository = asutusRepository;
    }

    public async Task<AsutusDto?> Handle(AsutusByKoodRequest request, CancellationToken cancellationToken)
    {
        return await _asutusRepository.GetAsutusAsync(request.Code, cancellationToken);
    }
}