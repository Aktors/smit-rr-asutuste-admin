using asutus.common.Model;
using asutus.domain.Entities;

namespace asutus.domain.Data.Repositories;

public interface IMessageLogRepository
{
    Task AddMessageAsync(MessageLog messageLog);
    Task<MessageLog?> GetMessageAsync(Guid referenceId);
    Task UpdateAsync(MessageLog messageLog);
    Task<QueryResultDto<ReplicationLogDto>> GetLogs(ReplicationLogQueryDto query);
}