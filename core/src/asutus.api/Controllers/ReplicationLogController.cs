using asutus.api.Commands;
using asutus.api.Helpers;
using asutus.api.Model;
using asutus.common.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace asutus.api.Controllers;

[Route("/replication")]
public class ReplicationLogController : ControllerBase
{    
    private readonly IMediator _mediator;
    
    public ReplicationLogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("log")]
    public async Task<IActionResult> GetLogs(ReplicationLogQuery query)
    {
        var searchQuery = new ReplicationLogQueryCommand(query.Map());
        return Ok(await _mediator.Send(searchQuery));
    }
    
    [HttpPost("/add")]
    public async Task<IActionResult> Update([FromBody]ReplicationDto[] request)
    {
        foreach (var replication in request)
            await _mediator.Send(new ReplicateAsutusCommand(replication));
        return Ok();
    }
}