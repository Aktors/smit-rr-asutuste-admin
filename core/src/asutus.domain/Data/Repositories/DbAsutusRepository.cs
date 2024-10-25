using asutus.common.Model;
using asutus.domain.Entities;
using asutus.domain.Helpers.Mappers;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data.Repositories;

public class DbAsutusRepository : IAsutusRepository
{
    private readonly AsutusContext _asutusContext;
    
    public DbAsutusRepository(AsutusContext context)
    {
        _asutusContext = context;
    }
    public async Task AddOrUpdateAsync(AsutusDto asutusDto
        ,CancellationToken cancellationToken = default)
    {
        var asutus = await _asutusContext.Asutused
            .FirstOrDefaultAsync(a => a.Code.Equals(asutusDto.Code),cancellationToken);

        if (asutus == null)
        {
            asutus = new Asutus {
                Code = asutusDto.Code
            };
            _asutusContext.Asutused.Attach(asutus);
        }
        //TODO: add translations mapping logic
        asutus.Name = asutusDto.Name;
        
        await _asutusContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<AsutusDto?> GetAsutusAsync(string code
        ,CancellationToken cancellationToken = default)
    {
        var result = await _asutusContext.Asutused
            .FirstOrDefaultAsync(a => a.Code.Equals(code), cancellationToken);
        return result?.Map();
    }

    public async Task<QueryResultDto<AsutusShortDto>> SearchAsync(AsutusteQueryDto query
        ,CancellationToken cancellationToken = default)
    {
        var queryable = _asutusContext.Asutused.AsQueryable();
        
        if(query.Code != null)
            queryable = queryable.Where(a => a.Code.Contains(query.Code));
        
        if(query.Name != null)
            queryable = queryable.Where(a => a.Name.ToLower().Contains(query.Name.ToLower()));

        if (query.StartDate.HasValue)
            queryable = queryable.Where(a => a.StartDate >= query.StartDate);
        
        if (query.EndDate.HasValue)
            queryable = queryable.Where(a => a.EndDate <= query.EndDate);

        if (query.Pagination is { SortOrder: not null, SortBy: not null })
        {
            var isDesc = query.Pagination.SortOrder.ToLower().Equals("desc");
            // Sorting
            queryable = query.Pagination.SortBy.ToLower() switch
            {
                nameof(AsutusShortDto.Name) => isDesc  ? queryable.OrderByDescending(e => e.Name) : queryable.OrderBy(e => e.Name),
                nameof(AsutusShortDto.StartDate) => isDesc ? queryable.OrderByDescending(e => e.StartDate) : queryable.OrderBy(e => e.StartDate),
                nameof(AsutusShortDto.EndDate) => isDesc ? queryable.OrderByDescending(e => e.EndDate) : queryable.OrderBy(e => e.EndDate),
                _ => isDesc ? queryable.OrderByDescending(e => e.Code) : queryable.OrderBy(e => e.Code),
            };
        }
        
        // Pagination
        var totalEntries = queryable.Count();
        var totalPages = 0;
        
        if (query.Pagination is { PageSize: not null, Page: not null })
        {
            totalPages = (int)Math.Ceiling(totalEntries / (double)query.Pagination.PageSize);
            queryable = queryable
                .Skip((query.Pagination.Page.Value - 1) * query.Pagination.PageSize.Value)
                .Take(query.Pagination.PageSize.Value);
        }

        return new QueryResultDto<AsutusShortDto>
        {
            Result = await queryable.Select(a => a.MapShortDto()).ToArrayAsync(cancellationToken),
            Total = totalEntries,
            Page = query.Pagination?.Page,
            PageSize = query.Pagination?.PageSize,
            TotalPages = totalPages
        };
    }
}