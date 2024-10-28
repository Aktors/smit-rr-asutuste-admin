using asutus.common.Model;
using asutus.domain.Entities;

namespace asutus.domain.Data.Repositories;

public interface IMessageLogRepository
{
    Task AddMessageAsync(ReplicationLogDto messageLog, CancellationToken cancellationToken = default);
    Task<ReplicationLogDto?> GetMessageAsync(Guid referenceId, CancellationToken cancellationToken = default);
    Task UpdateAsync(ReplicationLogDto messageLog, CancellationToken cancellationToken = default);
    Task<QueryResultDto<ReplicationLogDto>> GetLogsAsync(ReplicationLogQueryDto query,
        CancellationToken cancellationToken = default);
}