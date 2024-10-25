using asutus.api.Commands;
using asutus.api.Model;
using asutus.common.Model;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

[Route("asutus")]
public class AsutusController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AsutusController(IMediator mediator)
    {
       _mediator = mediator;
    }
    
    [HttpGet("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        var result = await _mediator.Send(new AsutusByKoodCommand(code));
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetList(AsutusteQuery query)
    {
        var searchQuery = new AsutusteLoeteluCommand(query);
        return Ok(await _mediator.Send(searchQuery));
    }
    
    [HttpPatch("{code}")]
    public async Task<IActionResult> Update(string code, [FromBody] JsonPatchDocument<AsutusDto> patchDoc)
    {
        var asutus = await _mediator.Send(new AsutusByKoodCommand(code));
        if (asutus == null)
            return NotFound();
        
        //TODO: Add validation.
        patchDoc.ApplyTo(asutus);

        var command = new UuendaAsutusCommand(asutus);
        await _mediator.Send(command);
        return Ok();
    }
}