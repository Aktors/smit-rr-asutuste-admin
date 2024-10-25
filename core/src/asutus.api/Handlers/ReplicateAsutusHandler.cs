using asutus.api.Commands;
using asutus.api.services;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class ReplicateAsutusHandler: IRequestHandler<ReplicateAsutusCommand, Unit>
{
    private readonly IAsutusRepository _asutusRepository;
    private readonly IReplicationService _replicationService;

    public ReplicateAsutusHandler(IAsutusRepository asutusRepository, IReplicationService replicationService)
    {
        _asutusRepository = asutusRepository;
        _replicationService = replicationService;
    }

    public async Task<Unit> Handle(ReplicateAsutusCommand command, CancellationToken cancellationToken)
    {
        //TODO: Add error handling
        var asutus = await _asutusRepository.GetAsutusAsync(command.Replication.Code);
        await _replicationService.Replicate(asutus, command.Replication);
        return Unit.Value;
    }
}