namespace asutus.api.services;

public interface IMessageLogService
{
    Task<Guid> InitMessage(String caption);
    Task ConfirmMessageAsync(Guid referenceId, String content);
}