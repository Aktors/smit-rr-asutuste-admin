using System.ComponentModel.DataAnnotations;

namespace asutus.domain.Entities;

public class MessageLog
{
    [Key]
    public int Id { get; set; }
    public Guid ReferenceId { get; set; }
    //TODO: add description: something used to identify message purpose, surrogate key like structure that contains sybsystem code, instance code and codificator code
    public string Caption { get; set; }
    //TODO: add description: actual content received from message
    public string? Content { get; set; }
    //TODO: add description: used to capture the timewhem message went to queue. When it is set, means message were confirmed from queue. Add something better and mor straightforward 
    public DateTime? SentDate { get; set; }
}