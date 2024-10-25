﻿using asutus.domain.Data.Repositories;
using asutus.domain.Entities;

namespace asutus.api.services;

public class DbMessageLogService : IMessageLogService
{
    private readonly IMessageLogRepository _repository;

    public DbMessageLogService(IMessageLogRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> InitMessageAsync(String caption, CancellationToken cancellationToken = default)
    {
        var referenceId = Guid.NewGuid();
        await _repository.AddMessageAsync(new MessageLog {
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
}