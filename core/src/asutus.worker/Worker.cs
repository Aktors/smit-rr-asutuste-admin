using asutus.bl.Services;
using asutus.worker.model;
using asutus.worker.services;

namespace asutus.worker;

public class Worker : BackgroundService
{
    private readonly IMessageListener _listener;
    private readonly IMessageLogService _messageLog;

    public Worker(
        IMessageLogService messageLog,
        IMessageListener listener)
    {
        _messageLog = messageLog;
        _listener = listener;

        _listener.MessageArrived += async (sender, e) 
            => await OnMessageArrived(sender, e);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var queues = await _messageLog.GetQueueNamesAsync(stoppingToken);
        foreach (var queue in queues)
            _listener.StartListening(queue);
    }
    
    private async Task  OnMessageArrived(object? sender, MessageArrivedEventArgs e
        , CancellationToken cancelationToken = default)
    {
        await _messageLog.ConfirmMessageAsync(e.ReferenceId, e.Message, cancelationToken);
    }
}