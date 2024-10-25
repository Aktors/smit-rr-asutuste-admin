using asutus.api.Commands;
using asutus.api.Exceptions;
using asutus.api.services;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class ReplicateAsutusHandler: IRequestHandler<ReplicateAsutusRequest, Unit>
{
    private readonly IAsutusRepository _asutusRepository;
    private readonly IReplicationService _replicationService;

    public ReplicateAsutusHandler(IAsutusRepository asutusRepository, IReplicationService replicationService)
    {
        _asutusRepository = asutusRepository;
        _replicationService = replicationService;
    }

    public async Task<Unit> Handle(ReplicateAsutusRequest request, CancellationToken cancellationToken)
    {
        var asutus = await _asutusRepository.GetAsutusAsync(request.Code, cancellationToken);
        if (asutus == null)
            throw new InvalidParamArgumentException("Invalid code : " + request.Code);
        await _replicationService.ReplicateAsync(asutus, request.Replication, cancellationToken);
        return Unit.Value;
    }
}