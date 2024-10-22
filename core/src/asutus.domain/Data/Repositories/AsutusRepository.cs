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
    public async Task AddOrUpdateAsync(AsutusDto asutusDto)
    {
        var asutus = await _asutusContext.Asutused
            .FirstOrDefaultAsync(a => a.Code.Equals(asutusDto.Code));

        if (asutus == null)
        {
            asutus = new Asutus {
                Code = asutusDto.Code
            };
            _asutusContext.Asutused.Attach(asutus);
        }
        //TODO: add translations mapping logic
        asutus.Name = asutusDto.Name;
        
        await _asutusContext.SaveChangesAsync();
    }

    public async Task<AsutusDto?> GetAsutusAsync(string code)
    {
        var result = await _asutusContext.Asutused
            .FirstOrDefaultAsync(a => a.Code.Equals(code));
        return result != null ? result.Map() : null;
    }
}