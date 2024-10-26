using asutus.api.Commands;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class ListSystemsHandler:  IRequestHandler<ListSystemsRequest, InformationSystemDto[]>
{    
    private readonly IAsutusRepository _asutusRepository;

    public ListSystemsHandler(IAsutusRepository asutusRepository)
    {
        _asutusRepository = asutusRepository;
    }

    public async Task<InformationSystemDto[]> Handle(ListSystemsRequest request, CancellationToken cancellationToken)
    {
        return await _asutusRepository.ListInformationSystems(cancellationToken);
    }
}