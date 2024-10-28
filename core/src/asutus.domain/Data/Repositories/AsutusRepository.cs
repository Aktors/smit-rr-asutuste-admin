using asutus.common.Exceptions;
using asutus.common.Model;
using asutus.domain.Entities;
using asutus.domain.Helpers.Mappers;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data.Repositories;

public class AsutusRepository : IAsutusRepository
{
    private readonly AsutusContext _asutusContext;
    private readonly Classifier[] _languages;

    public AsutusRepository(AsutusContext context)
    {
        _asutusContext = context;
        _languages = context.Classifiers.Where(c => c.Group.Equals("Language")).ToArray();
    }

    public async Task AddOrUpdateAsync(AsutusDto asutusDto
        , CancellationToken cancellationToken = default)
    {
        var asutus = await GetByCodeAsync(asutusDto.Code, cancellationToken);
        if (asutus == null)
        {
            asutus = new Asutus
            {
                Code = asutusDto.Code,
                Translations = new List<Translation>()
            };
            _asutusContext.Asutused.Attach(asutus);
        }

        asutus.Name = asutusDto.Name;
        asutus.StartDate = asutusDto.StartDate;
        asutus.EndDate = asutusDto.EndDate;

        SyncTranslations(asutus, asutusDto.Translations);

        await _asutusContext.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<AsutusDto?> GetAsutusAsync(string code
        , CancellationToken cancellationToken = default)
    {
        var result = await GetByCodeAsync(code, cancellationToken);
        if(result == null)
            throw new NotFoundDomainException($"Entity of {nameof(Asutus)} not found by code:{code}");
        return result.Map();
    }

    public async Task DeleteByCodeAsync(string asutusCode,
        CancellationToken cancellationToken = default)
    {
        var result = await GetByCodeAsync(asutusCode, cancellationToken);
        if(result == null)
            throw new NotFoundDomainException($"Entity of {nameof(Asutus)} not found by code:{asutusCode}");
        _asutusContext.Asutused.Remove(result);
        await _asutusContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<QueryResultDto<AsutusShortDto>> SearchAsync(AsutusteQueryDto query
        , CancellationToken cancellationToken = default)
    {
        var queryable = _asutusContext.Asutused.AsQueryable();

        if (query.Code != null)
            queryable = queryable.Where(a => a.Code.Contains(query.Code));

        if (query.Name != null)
            queryable = queryable.Where(a => a.Name.ToLower().Contains(query.Name.ToLower()));

        if (query.StartDate.HasValue)
            queryable = queryable.Where(a => a.StartDate >= query.StartDate);

        if (query.EndDate.HasValue)
            queryable = queryable.Where(a => a.EndDate <= query.EndDate);

        if (query.Pagination is { SortOrder: not null, SortBy: not null })
        {
            var isDesc = query.Pagination.SortOrder.ToLower().Equals("desc");
            queryable = query.Pagination.SortBy.ToLower() switch
            {
                nameof(AsutusShortDto.Name) => isDesc
                    ? queryable.OrderByDescending(e => e.Name)
                    : queryable.OrderBy(e => e.Name),
                nameof(AsutusShortDto.StartDate) => isDesc
                    ? queryable.OrderByDescending(e => e.StartDate)
                    : queryable.OrderBy(e => e.StartDate),
                nameof(AsutusShortDto.EndDate) => isDesc
                    ? queryable.OrderByDescending(e => e.EndDate)
                    : queryable.OrderBy(e => e.EndDate),
                _ => isDesc ? queryable.OrderByDescending(e => e.Code) : queryable.OrderBy(e => e.Code),
            };
        }

        var totalEntries = queryable.Count();
        var totalPages = 0;

        if (query.Pagination is { PageSize: not null, Page: not null })
        {
            totalPages = (int)Math.Ceiling(totalEntries / (double)query.Pagination.PageSize);
            queryable = queryable
                .Skip((query.Pagination.Page.Value) * query.Pagination.PageSize.Value)
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

    public async Task<ClassifierDto[]> GetClassifierByGroup(string code,
        CancellationToken cancellationToken = default)
    {
        return await _asutusContext.Classifiers
            .Where(c => c.Group.Equals(code))
            .Select(c => new ClassifierDto { Code = c.Code, Name = c.Name })
            .ToArrayAsync(cancellationToken);
    }


    private async Task<Asutus?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
    {
        return await _asutusContext.Asutused
            .Include(a => a.Translations)
            .ThenInclude(t => t.Language)
            .FirstOrDefaultAsync(a => a.Code.Equals(code), cancellationToken);
    }
    
    
    private void  SyncTranslations(
        Asutus asutus, 
        List<TranslationDto> translations)
    {
        var oldTranslations = asutus.Translations.ToList();
        asutus.Translations.Clear();
        
        foreach (var udpatedTranslation in translations)
        {
            var lang = _languages.SingleOrDefault(l => l.Code.Contains(udpatedTranslation.Code));
            if (lang == null)
                continue;
            
            var currentTranslation = oldTranslations.SingleOrDefault(t => t.LanguageId.Equals(lang.Id)) ?? 
                                     new Translation {LanguageId = lang.Id};

            asutus.Translations.Add(currentTranslation);
            currentTranslation.Text = udpatedTranslation.Text;
        }
    }
}