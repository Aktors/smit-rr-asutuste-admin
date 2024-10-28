using asutus.common.Model;
using asutus.domain.Entities;
using asutus.domain.Helpers.Mappers;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data.Repositories;

public class MessageLogRepository : IMessageLogRepository
{
    private readonly AsutusContext _asutusContext;

    public MessageLogRepository(AsutusContext asutusContext)
    {
        _asutusContext = asutusContext;
    }
    
    public async Task AddMessageAsync(ReplicationLogDto replicationLogDto, CancellationToken cancellationToken = default)
    {
        _asutusContext.MessageLogs.Add(replicationLogDto.Map());
        await _asutusContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<ReplicationLogDto?> GetMessageAsync(Guid referenceId, CancellationToken cancellationToken = default)
    {
        var messageLog = await _asutusContext.MessageLogs
            .FirstOrDefaultAsync(x => x.ReferenceId == referenceId, cancellationToken);
        return messageLog?.Map();
    }

    public async Task UpdateAsync(ReplicationLogDto replicationLog, CancellationToken cancellationToken = default)
    {
        var messageLog = await _asutusContext.MessageLogs
            .FirstOrDefaultAsync(x => x.ReferenceId == replicationLog.ReferenceId, cancellationToken);
        if(messageLog == null)
            return;
        messageLog.Content = replicationLog.Content;
        messageLog.SentDate = replicationLog.SentDate;
        _asutusContext.MessageLogs.Update(messageLog);
        
        await _asutusContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<QueryResultDto<ReplicationLogDto>> GetLogsAsync(ReplicationLogQueryDto query,
        CancellationToken cancellationToken = default)
    { 
        var queryable = _asutusContext.MessageLogs.AsQueryable();

        if (query.Pagination is { SortOrder: not null, SortBy: not null })
        {
            var isDesc = query.Pagination.SortOrder.ToLower().Equals("desc");
            queryable = query.Pagination.SortBy.ToLower() switch
            {
                nameof(ReplicationLogDto.Caption) => isDesc ? 
                    queryable.OrderByDescending(e => e.Caption) :
                    queryable.OrderBy(e => e.Caption),
                _ => isDesc ? 
                    queryable.OrderByDescending(e => e.SentDate) :
                    queryable.OrderBy(e => e.SentDate)
            };
        }
        
        var totalEntries = queryable.Count();
        var totalPages = 0;

        if (query.Pagination is { PageSize: not null, Page: not null })
        {
            totalPages = (int)Math.Ceiling(totalEntries / (double)query.Pagination.PageSize.Value);
            queryable = queryable
                .Skip((query.Pagination.Page.Value - 1) * query.Pagination.PageSize.Value)
                .Take(query.Pagination.PageSize.Value);
        }
        
        return new QueryResultDto<ReplicationLogDto>
        {
            Result = await queryable.Select(ml => ml.Map()).ToArrayAsync(cancellationToken),
            Total = totalEntries,
            Page = query.Pagination.Page,
            PageSize = query.Pagination.PageSize,
            TotalPages = totalPages
        };
    }
}