namespace asutus.common.Model;

public class ReplicationLogDto
{
    public Guid ReferenceId { get; set; }
    public string Caption { get; set; }
    public string? Content { get; set; }
    public DateTime? SentDate { get; set; }
}