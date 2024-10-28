using asutus.common.Model;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data.Repositories;

public class InformationSystemRepository : IInformationSystemRepository
{   
    private readonly AsutusContext _asutusContext;
    

    public InformationSystemRepository(AsutusContext context)
    {
        _asutusContext = context;
    }
    
    public async Task<InformationSystemDto[]> ListInformationSystems(CancellationToken cancellationToken = default)
    {
        return await _asutusContext.InformationSystems
            .Include(s => s.SystemInstances)
            .ThenInclude(i => i.InstanceType)
            .Select(c => new InformationSystemDto()
            {
                Code = c.Code,
                Name = c.Name,
                Instances = c.SystemInstances.Select(si => si.InstanceType.Code).ToArray()
            })
            .ToArrayAsync(cancellationToken);
    }
}