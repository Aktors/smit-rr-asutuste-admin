namespace asutus.bl.Services;

public interface IMessageLogService
{
    Task<Guid> InitMessageAsync(String caption, CancellationToken cancellationToken = default);
    Task ConfirmMessageAsync(Guid referenceId, String content, CancellationToken cancellationToken = default);
    Task<String[]> GetQueueNamesAsync(CancellationToken cancellationToken = default);
}