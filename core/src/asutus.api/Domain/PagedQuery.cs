using Microsoft.AspNetCore.Mvc;

namespace asutus.api.Model;

public class PagedQuery
{

    [FromQuery(Name = "page")]
    public int? Page { get; set; }

    [FromQuery(Name = "pageSize")]
    public int? PageSize { get; set; }

    [FromQuery(Name = "sortBy")]
    public string?  SortBy { get; set; }

    [FromQuery(Name = "sortOrder")]
    public string? SortOrder { get; set; }
    
}