namespace asutus.common.Model;

public class AsutusteQueryDto
{
    public string?  Code { get; set; }
    public string?  Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    
    public Pagination Pagination { get; set; } = new();
}