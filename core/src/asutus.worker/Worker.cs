using asutus.bl.Commands;
using asutus.bl.Services;
using asutus.worker.model;
using asutus.worker.services;
using MediatR;

namespace asutus.worker;

public class Worker : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly IMessageListener  _listener;
    
    public Worker(
        IServiceProvider services,
        IMessageListener listener)
    {
        _services = services;
        _listener = listener;

        _listener.MessageArrived += async (sender, e) 
            => await OnMessageArrived(sender, e);
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var scope = _services.CreateScope();
        var messageLog = scope.ServiceProvider.GetRequiredService<IMessageLogService>();
        var queues = await messageLog.GetQueueNamesAsync(cancellationToken);
        foreach (var queue in queues)
            _listener.StartListening(queue);
    }
    
    private async Task  OnMessageArrived(object? sender, MessageArrivedEventArgs e
        , CancellationToken cancelationToken = default)
    {
        using var scope = _services.CreateScope();
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(new ConfirmReplicationLogRequest(e.ReferenceId, e.Message), cancelationToken);
    }
}