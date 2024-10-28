using asutus.api.Commands;
using asutus.api.services;
using asutus.common.Exceptions;
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
        try
        {
            var asutus = await _asutusRepository.GetAsutusAsync(request.Code, cancellationToken);
            await _replicationService.ReplicateAsync(asutus, request.Replication, cancellationToken);
        }
        catch (NotFoundDomainException e)
        {            
            throw new InvalidArgumentDomainException("Invalid code : " + request.Code, e);
        }
        return Unit.Value;
    }
}