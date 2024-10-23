using asutus.api.Facades;
using asutus.api.Model;
using asutus.common.Model;
using Microsoft.AspNetCore.Mvc;

[Route("asutus")]
public class AsutusController : ControllerBase
{
    private readonly AsutusFacade _asutusFacade;
    
    public AsutusController(AsutusFacade asutusFacade)
    {
        _asutusFacade = asutusFacade;
    }
    
    [HttpGet("{code}")]
    public async Task<IActionResult> Get(string code)
    {
        var result = await _asutusFacade.SearchByCodeAsync(code);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    
    [HttpGet("list")]
    public async Task<IActionResult> GetList(AsutusteQuery query)
    {
        return Ok(await _asutusFacade.SearchAsync(query));
    }

    [HttpPatch("{code}")]
    public async Task<IActionResult> Update()
    {
        await _asutusFacade.UpdateRecord(new AsutusDto
        {
            Code = "IPV",
            Name = "Tallina Perekonnaseisuamet",
            Translations =
            [
                new Translation { Code = "ENG", Text = "Some text1" },
                new Translation { Code = "Rus", Text = "Some text2" }
            ]
        }, new[]
        {
            new ReplicationDto { Code = "RRKP", Environments = ["DEV", "TEST"] },
        });
        return Ok();
    }
}