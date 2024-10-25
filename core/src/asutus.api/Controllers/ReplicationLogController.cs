using asutus.api.Commands;
using asutus.api.Helpers;
using asutus.api.Model;
using asutus.common.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace asutus.api.Controllers;

[Route("api/v1/replication")]
public class ReplicationLogController : ControllerBase
{    
    private readonly IMediator _mediator;
    
    public ReplicationLogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("log")]
    [SwaggerOperation(
        Summary = "Tagastab teavituste logi",
        Description = "Tagastab teavituse sõnumi koos staatusega")]
    [SwaggerResponse(200, "List of replication messages", typeof(QueryResultDto<ReplicationLogDto>))]
    [SwaggerResponse(400, "Otsingu parameetrid ei ole valiidsed")]
    public async Task<IActionResult> GetLogs(ReplicationLogQuery query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var searchQuery = new ReplicationLogQueryRequest(query.Map());
        return Ok(await _mediator.Send(searchQuery));
    }
    
    [HttpPost("publish/{code}")]
    [SwaggerOperation(
        Summary = "Publitseeri asutuse andmete uuendused", 
        Description = "Saadab teavitused asutuste muudatusets alamsüsteemidesse.")]
    [SwaggerResponse(201, "Teavitused edukalt saadetud")]
    [SwaggerResponse(400, "Sisend on vale")] 
    public async Task<IActionResult> Publish(
        [FromRoute]
        [SwaggerParameter(Description = "Asutuse kood mille kohta saadetakse teavitused")] 
        string code,
        [FromBody]
        [SwaggerParameter(Description = "Nimekiri süsteemidest kuhu saadetakse teavitused")] 
        ReplicationDto[] request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        foreach (var replication in request)
            await _mediator.Send(new ReplicateAsutusRequest(code, replication));
        return Created();
    }
}