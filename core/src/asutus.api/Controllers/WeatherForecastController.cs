using asutus.api.Domain;
using asutus.api.Facades;
using asutus.api.services;
using asutus.common.Model;
using Microsoft.AspNetCore.Mvc;

namespace asutus.api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly AsutusFacade _asutusFacade;
    public WeatherForecastController(AsutusFacade asutusFacade)
    {
        _asutusFacade = asutusFacade;
    }
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        await _asutusFacade.UpdateRecord( new AsutusDto
        {
            Code = "IPV",
            Name = "Tallina Perekonnaseisuamet",
            Translations =
            [
                new Translation { Code = "ENG", Text = "Some text1" },
                new Translation { Code = "Rus", Text = "Some text2" }
            ]
        },new []
        {
            new ReplicationDto{ Code = "RRKP" , Enviroments = ["DEV","TEST"] },
        });
       
        
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}