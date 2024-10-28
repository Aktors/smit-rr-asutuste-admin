namespace asutus.worker.model;

public class MessageArrivedEventArgs : EventArgs
{
    public MessageArrivedEventArgs(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
    public Guid ReferenceId { get; set; }
}