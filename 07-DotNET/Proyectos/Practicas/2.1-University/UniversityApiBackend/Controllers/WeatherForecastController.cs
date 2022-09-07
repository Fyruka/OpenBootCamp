using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UniversityApiBackend.Controllers
{
    [ApiController]
    [Route("[controller]")] // localhost:7190/WeatherForecast
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger; // 1. En este caso tenemos el Iloggerr ya montado en este controlador. Desde este momento podemos empezar a utilizarlo 

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger; // 2. Inicializamos la instancia en el contructor 
        }

        // Method: GET => Get to localhost:7190/WeatherForecast

        [HttpGet(Name = "GetWeatherForecast")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator, User")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogTrace($"{nameof(WeatherForecastController)} - {nameof(Get)} - Trace Level Log"); // 3. Primero que nos de el nombre de que controlador o donde viene el error, y luego que coja el nombre de la funcion que a fallado. 
            _logger.LogDebug($"{nameof(WeatherForecastController)} - {nameof(Get)} - Debug Level Log");
            _logger.LogInformation($"{nameof(WeatherForecastController)} - {nameof(Get)} - Information Level Log");
            _logger.LogWarning($"{nameof(WeatherForecastController)} - {nameof(Get)} - Warning Level Log");
            _logger.LogError($"{nameof(WeatherForecastController)} - {nameof(Get)} - Error Level Log");
            _logger.LogCritical($"{nameof(WeatherForecastController)} - {nameof(Get)} - Critical Level Log");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}