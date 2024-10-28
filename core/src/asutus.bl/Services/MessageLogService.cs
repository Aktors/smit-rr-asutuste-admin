using asutus.common.Model;
using asutus.domain.Data.Repositories;

namespace asutus.bl.Services;

public class DbMessageLogService : IMessageLogService
{
    private readonly IMessageLogRepository _repository;
    private readonly IInformationSystemRepository _systems;

    public DbMessageLogService(
        IMessageLogRepository repository,
        IInformationSystemRepository systems)
    {
        _systems = systems;
        _repository = repository;
    }

    public async Task<Guid> InitMessageAsync(String caption, CancellationToken cancellationToken = default)
    {
        var referenceId = Guid.NewGuid();
        await _repository.AddMessageAsync(new ReplicationLogDto {
            Caption = caption,
            ReferenceId = referenceId
        }, cancellationToken);
        return referenceId;
    }

    public async Task ConfirmMessageAsync(Guid referenceId, String content
        , CancellationToken cancellationToken = default)
    {
        var message = await _repository.GetMessageAsync(referenceId,cancellationToken);
        if (message != null)
        {
            message.Content = content;
            message.SentDate = DateTime.Now;
            await _repository.UpdateAsync(message, cancellationToken);
        }
    }
    
    public async Task<String[]> GetQueueNamesAsync(CancellationToken cancellationToken = default)
    {
        var systems =  await _systems.ListInformationSystems(cancellationToken);
        return (from system in systems from instance in system.Instances select $"{system.Code}_{instance}").ToArray();
    }
}