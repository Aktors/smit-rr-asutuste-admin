
using asutus.api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace asutus.api.Controllers;

[Route("api/v1/system")]
public class SystemController : ControllerBase
{      
    private readonly IMediator _mediator;
    
    public SystemController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("classifier/{group}/list")]
    public async Task<IActionResult> GetClassifiers(string group)
    {
        return Ok(await _mediator.Send(new ClassifierByGroupRequest(group)));
    }
    
    [HttpGet("information-systems/list")]
    public async Task<IActionResult> GetSystems()
    {
        return Ok(await _mediator.Send(new ListSystemsRequest()));
    }
}