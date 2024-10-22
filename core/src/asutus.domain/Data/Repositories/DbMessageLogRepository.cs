using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace asutus.domain.Data.Repositories;

public class DbMessageLogRepository : IMessageLogRepository
{
    //TODO: may be separate context by topics
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
}