using asutus.api.Commands;
using asutus.api.Model;
using asutus.api.Model.Model;
using asutus.common.Model;
using MediatR;
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
    [SwaggerResponse(404, "Asutus antud koodiga ei eksisteeri", typeof(RequestFault))]
    public async Task<IActionResult> Get(string code)
    {
        var result = await _mediator.Send(new AsutusByKoodRequest(code));
        return Ok(result);
    }
    
    [HttpDelete("{code}")]
    [SwaggerOperation(Summary = "Eemaldab Asutuse koodi järgi")]
    [SwaggerResponse(404, "Otsingu parameetrid ei ole valiidsed", typeof(RequestFault))]
    public async Task<IActionResult> DeleteAsutus(string code)
    {
        await _mediator.Send(new DeleteAsutusByCodeRequest(code));
        return NoContent();
    }
    
    [HttpGet("list")]
    [SwaggerOperation(
        Summary = "Asutuste nimekiri", 
        Description = "Tagastab lühendatud andmestiku asutuste kohta.")]
    [SwaggerResponse(200, "Asutuste nimekiri", typeof(QueryResultDto<AsutusShortDto>))]
    [SwaggerResponse(400, "Otsingu parameetrid ei ole valiidsed", typeof(RequestFault))]
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
    [SwaggerResponse(404, "Asutus selle koodiga ei leia", typeof(RequestFault))]
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