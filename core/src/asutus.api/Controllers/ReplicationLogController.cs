using asutus.api.Facades;
using asutus.api.Model;
using Microsoft.AspNetCore.Mvc;

namespace asutus.api.Controllers;

[Route("/replication")]
public class ReplicationLogController : ControllerBase
{
    private readonly ReplicationFacade _facade;
    
    public ReplicationLogController(ReplicationFacade facade)
    {
        _facade = facade;   
    }

    [HttpGet("log")]
    public async Task<IActionResult> GetLogs(ReplicationLogQuery query)
    {
        return Ok(await _facade.GetLogs(query));
    }
}