using asutus.domain.Data;

namespace asutus.api.Helpers;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AsutusContext _context;

    public UnitOfWork(AsutusContext context)
    {
        _context = context;
    }

    public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}