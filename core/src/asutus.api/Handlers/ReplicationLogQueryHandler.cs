using asutus.api.Commands;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using MediatR;

namespace asutus.api.Handlers;

public class ReplicationLogQueryHandler: IRequestHandler<ReplicationLogQueryCommand, QueryResultDto<ReplicationLogDto>>
{
    private readonly IMessageLogRepository _messageLogRepository;

    public ReplicationLogQueryHandler(IMessageLogRepository messageLogRepository)
    {
        _messageLogRepository = messageLogRepository;
    }

    public async Task<QueryResultDto<ReplicationLogDto>> Handle(
        ReplicationLogQueryCommand command, CancellationToken cancellationToken)
    {
        return await _messageLogRepository.GetLogs(command.Query);
    }
}