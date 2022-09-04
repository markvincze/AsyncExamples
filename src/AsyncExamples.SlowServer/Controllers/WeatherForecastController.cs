using Microsoft.AspNetCore.Mvc;

namespace AsyncExamples.SlowServer.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get([FromQuery]int waitTimeMs)
    {
        await Task.Delay(waitTimeMs);

        return Enumerable.Range(1, 3).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("/fail")]
    public async Task<IActionResult> Fail([FromQuery]int waitTimeMs)
    {
        await Task.Delay(waitTimeMs);

        return StatusCode(StatusCodes.Status500InternalServerError, "Processing the request failed.");
    }
}
