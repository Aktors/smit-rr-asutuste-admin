using Microsoft.AspNetCore.Mvc;

namespace asutus.api.Model;

public class AsutusteQuery : PagedQuery
{
    [FromQuery(Name = "code")]
    public string?  Code { get; set; }

    [FromQuery(Name = "name")]
    public string?  Name { get; set; }

    [FromQuery(Name = "startDate")]
    public DateTime? StartDate { get; set; }

    [FromQuery(Name = "endDate")]
    public DateTime? EndDate { get; set; }
    
}