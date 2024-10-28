using asutus.bl.Commands;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.bl.Handlers;

public class ListSystemsHandler:  IRequestHandler<ListSystemsRequest, InformationSystemDto[]>
{    
    private readonly IInformationSystemRepository _repository;

    public ListSystemsHandler(IInformationSystemRepository repository)
    {
        _repository = repository;
    }

    public async Task<InformationSystemDto[]> Handle(ListSystemsRequest request, CancellationToken cancellationToken)
    {
        return await _repository.ListInformationSystems(cancellationToken);
    }
}