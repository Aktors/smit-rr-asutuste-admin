using asutus.api.Commands;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class DeleteAsutusByCodeHandler: IRequestHandler<DeleteAsutusByCodeRequest,Unit>
{
    private readonly IAsutusRepository _asutusRepository;

    public DeleteAsutusByCodeHandler(IAsutusRepository asutusRepository)
    {
        _asutusRepository = asutusRepository;
    }

    public async Task<Unit> Handle(DeleteAsutusByCodeRequest request, CancellationToken cancellationToken)
    {
        await _asutusRepository.DeleteByCodeAsync(request.Code, cancellationToken);
        return Unit.Value;
    }
}