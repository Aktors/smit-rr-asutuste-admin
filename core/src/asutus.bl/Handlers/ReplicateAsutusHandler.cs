using asutus.bl.Commands;
using asutus.bl.Services;
using asutus.common.Exceptions;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.bl.Handlers;

public class ReplicateAsutusHandler: IRequestHandler<ReplicateAsutusRequest, Unit>
{
    private readonly IAsutusRepository _asutusRepository;
    private readonly IReplicationPublisherService _replicationPublisherService;

    public ReplicateAsutusHandler(IAsutusRepository asutusRepository, IReplicationPublisherService replicationPublisherService)
    {
        _asutusRepository = asutusRepository;
        _replicationPublisherService = replicationPublisherService;
    }

    public async Task<Unit> Handle(ReplicateAsutusRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var asutus = await _asutusRepository.GetAsutusAsync(request.Code, cancellationToken);
            await _replicationPublisherService.ReplicateAsync(asutus, request.Replication, cancellationToken);
        }
        catch (NotFoundDomainException e)
        {            
            throw new InvalidArgumentDomainException("Invalid code : " + request.Code, e);
        }
        return Unit.Value;
    }
}