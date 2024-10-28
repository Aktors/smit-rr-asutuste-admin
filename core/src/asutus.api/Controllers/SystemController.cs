using asutus.api.Model.Model;
using asutus.bl.Commands;
using asutus.common.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerResponse(200, "Klassifikaatori väärtused", typeof(ClassifierDto[]))]
    [SwaggerResponse(404, "Tundmatu grupp", typeof(RequestFault))]
    public async Task<IActionResult> GetClassifiers(string group)
    {
        return Ok(await _mediator.Send(new ClassifierByGroupRequest(group)));
    }
    
    [HttpGet("information-systems/list")]
    [SwaggerResponse(200, "Alamsüsteemide loetelu", typeof(InformationSystemDto[]))]
    public async Task<IActionResult> GetSystems()
    {
        return Ok(await _mediator.Send(new ListSystemsRequest()));
    }
}