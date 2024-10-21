using asutus.api.Domain;
using asutus.api.services;
using Microsoft.AspNetCore.Mvc;

namespace asutus.api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly RabbitMQService _rabbitMQService;
    public WeatherForecastController(RabbitMQService rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _rabbitMQService.SendMessage($"GetWeatherForecast request was made to RabbitMQ at {DateTime.Now.ToShortTimeString()}");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}