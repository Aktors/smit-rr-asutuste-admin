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
    
    public async Task AddMessageAsync(MessageLog messageLog)
    {
        _asutusContext.MessageLogs.Add(messageLog);
        await _asutusContext.SaveChangesAsync();
    }

    public async Task<MessageLog?> GetMessageAsync(Guid referenceId)
    {
        return await _asutusContext.MessageLogs
            .FirstOrDefaultAsync(m => m.ReferenceId.Equals(referenceId));
    }

    public async Task UpdateAsync(MessageLog messageLog)
    {
        _asutusContext.Entry(messageLog).State = EntityState.Modified;
        await _asutusContext.SaveChangesAsync();
    }

    public async Task<QueryResultDto<ReplicationLogDto>> GetLogs(ReplicationLogQueryDto query)
    { 
        var queryable = _asutusContext.MessageLogs.AsQueryable();
        
        var isDesc = query.Pagination.SortOrder.ToLower().Equals("desc");
        queryable = query.Pagination.SortBy.ToLower() switch
        {
            nameof(ReplicationLogDto.Caption) => isDesc ? queryable.OrderByDescending(e => e.Caption) : queryable.OrderBy(e => e.Caption),
            _ => isDesc ? queryable.OrderByDescending(e => e.SentDate) : queryable.OrderBy(e => e.SentDate)
        };
        
        var totalEntries = queryable.Count();
        var totalPages = (int)Math.Ceiling(totalEntries / (double)query.Pagination.PageSize);
        
        var paginatedEntries = await queryable
            .Skip((query.Pagination.Page - 1) * query.Pagination.PageSize)
            .Take(query.Pagination.PageSize)
            .Select(ml => ml.Map()).ToArrayAsync();

        return new QueryResultDto<ReplicationLogDto>
        {
            Result = paginatedEntries,
            Total = totalEntries,
            Page = query.Pagination.Page,
            PageSize = query.Pagination.PageSize,
            TotalPages = totalPages
        };
    }
}