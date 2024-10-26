using asutus.api.Commands;
using asutus.api.Model;
using asutus.common.Model;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[Route("api/v1/asutus")]
public class AsutusController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public AsutusController(IMediator mediator)
    {
       _mediator = mediator;
    }
    
    [HttpGet("{code}")]
    [SwaggerOperation(
        Summary = "Tagastab asutuse andmestiku", 
        Description = "Tagastab asutuse andmestiku koodi järgi.")]
    [SwaggerResponse(200, "Asutus leitud", typeof(AsutusDto))]
    [SwaggerResponse(404, "Asutus antud koodiga ei eksisteeri")]
    public async Task<IActionResult> Get(string code)
    {
        var result = await _mediator.Send(new AsutusByKoodRequest(code));
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    
    [HttpGet("list")]
    [SwaggerOperation(
        Summary = "Asutuste nimekiri", 
        Description = "Tagastab lühendatud andmestiku asutuste kohta.")]
    [SwaggerResponse(200, "Asutuste nimekiri", typeof(QueryResultDto<AsutusShortDto>))]
    [SwaggerResponse(400, "Otsingu parameetrid ei ole valiidsed")]
    public async Task<IActionResult> GetList(AsutusteQuery query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var searchQuery = new AsutusteLoeteluRequest(query);
        return Ok(await _mediator.Send(searchQuery));
    }
    
    [HttpPut("{code}")]
    [SwaggerOperation(
        Summary = "Uuenda asutuse andmestik", 
        Description = "Uuendab olemasoleva asutuse andmestiku koodi järgi.")]
    [SwaggerResponse(201, "Asutuse andmesik on edukalt uuendatud")]
    [SwaggerResponse(400, "Päringu sisu on vale")]
    [SwaggerResponse(404, "Asutus selle koodiga ei leia")]
    public async Task<IActionResult> Update(
        [FromRoute]
        [SwaggerParameter(Description = "Asutuse kood")] 
        string code, 
        [FromBody]
        [SwaggerParameter(Description = "Asutuse andmestiku muudatused")] 
        AsutusDto asutus)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var command = new UuendaAsutusRequest(asutus);
        await _mediator.Send(command);
        return Created();
    }
}