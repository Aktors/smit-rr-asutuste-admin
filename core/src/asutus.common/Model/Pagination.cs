namespace asutus.common.Model;

public class Pagination
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string SortBy { get; set; }
    public string SortOrder { get; set; }
}