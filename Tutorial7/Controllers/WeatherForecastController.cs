using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tutorial7.Controllers
{
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherList(5, -20, 55);
        }

        [HttpGet("{n}/{min}/{max}")]
        public IEnumerable<WeatherForecast> Get(int n, int min, int max)
        {
            return WeatherList(n, min, max);
        }
        [HttpGet("{n}")]
        public IEnumerable<WeatherForecast> Get(int n)
        {
            return WeatherList(n, -20, 55);
        }
        
        private static IEnumerable<WeatherForecast> WeatherList(int n, int min, int max)
        {
            var rng = new Random();
            return Enumerable.Range(1, n).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(min, max),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}