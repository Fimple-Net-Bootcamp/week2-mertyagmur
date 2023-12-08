using Microsoft.AspNetCore.Mvc;
using SpaceWeather.Helpers;
using SpaceWeather.Models;

namespace SpaceWeather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private static List<CelestialBody> celestialBodies = CelestialBodyDataInitializer.InitializeCelestialBodies();

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetWeatherData(int id)
        {
            var celestialBody = celestialBodies.FirstOrDefault(c => c.Id == id);
            if (celestialBody == null)
            {
                return NotFound();
            }

            var random = new Random();
            var randomWeatherCondition = celestialBody.WeatherConditions[random.Next(celestialBody.WeatherConditions.Count)];
            var randomTemperature = GetRandomTemperature();

            var weatherData = new
            {
                CelestialBodyId = celestialBody.Id,
                CelestialBodyName = celestialBody.Name,
                Temperature = randomTemperature,
                WindSpeed = GetRandomWindSpeed(),
                Humidity = GetRandomHumidity(),
                Conditions = randomWeatherCondition,
                DateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };

            return Ok(weatherData);
        }

        private double GetRandomTemperature()
        {
            var random = new Random();
            return random.NextDouble() * (100 - (-100)) + (-100);
        }

        private double GetRandomWindSpeed()
        {
            var random = new Random();
            return random.NextDouble() * (30 - 1) + 1;
        }

        private int GetRandomHumidity()
        {
            var random = new Random();
            return random.Next(0, 101);
        }
    }
}
