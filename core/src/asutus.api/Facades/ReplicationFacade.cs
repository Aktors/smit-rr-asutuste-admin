using asutus.api.Helpers;
using asutus.api.Model;
using asutus.common.Model;
using asutus.domain.Data.Repositories;

namespace asutus.api.Facades;

public class ReplicationFacade
{    
    private readonly IMessageLogRepository _messageLogRepository;
    
    public ReplicationFacade(
        IMessageLogRepository messageLogRepository)
    {
        _messageLogRepository = messageLogRepository;
    }
    
    public async Task<QueryResultDto<ReplicationLogDto>> GetLogs(ReplicationLogQuery query)
    {
        return await _messageLogRepository.GetLogs(query.Map());
    }
}