using asutus.common.Model;
using asutus.domain.Entities;
using asutus.domain.Helpers.Mappers;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data.Repositories;

public class DbMessageLogRepository : IMessageLogRepository
{
    private readonly AsutusContext _asutusContext;

    public DbMessageLogRepository(AsutusContext asutusContext)
    {
        _asutusContext = asutusContext;
    }
    
    public async Task AddMessageAsync(MessageLog messageLog, CancellationToken cancellationToken = default)
    {
        _asutusContext.MessageLogs.Add(messageLog);
        await _asutusContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<MessageLog?> GetMessageAsync(Guid referenceId, CancellationToken cancellationToken = default)
    {
        return await _asutusContext.MessageLogs
            .FirstOrDefaultAsync(m => m.ReferenceId.Equals(referenceId), cancellationToken);
    }

    public async Task UpdateAsync(MessageLog messageLog, CancellationToken cancellationToken = default)
    {
        _asutusContext.Entry(messageLog).State = EntityState.Modified;
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