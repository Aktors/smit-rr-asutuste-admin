using asutus.bl.Commands;
using asutus.bl.Services;
using MediatR;

namespace asutus.bl.Handlers;

public class ConfirmReplicationLogHandler : IRequestHandler<ConfirmReplicationLogRequest,Unit>
{   
    private readonly IMessageLogService _messageLog;

    public ConfirmReplicationLogHandler(IMessageLogService messageLog)
    {
        _messageLog = messageLog;
    }

    public async Task<Unit> Handle(ConfirmReplicationLogRequest request, CancellationToken cancellationToken)
    {
        await _messageLog.ConfirmMessageAsync(request.ReferenceId, request.Conetnt, cancellationToken);
        return Unit.Value;
    }
}