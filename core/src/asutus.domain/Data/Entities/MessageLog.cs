using System.ComponentModel.DataAnnotations;

namespace asutus.domain.Entities;

public class MessageLog
{
    /// <summary>
    /// System identifier.
    /// </summary>
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Tracking reference used for message conformation.
    /// </summary>
    public Guid ReferenceId { get; set; }
    /// <summary>
    /// Caption is a message identifier composed of destination system code and environment name with asutus code. 
    /// </summary>
    public string Caption { get; set; }
    /// <summary>
    /// The message content received from queue.
    /// </summary>
    public string? Content { get; set; }
    /// <summary>
    /// The date when message was received from queue. If date is set, then message was confirmed.
    /// </summary>
    public DateTime? SentDate { get; set; }
}