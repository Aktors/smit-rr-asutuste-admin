namespace asutus.api.Helpers;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
}