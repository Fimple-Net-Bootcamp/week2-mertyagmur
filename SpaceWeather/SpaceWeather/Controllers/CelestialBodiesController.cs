using Microsoft.AspNetCore.Mvc;
using SpaceWeather.Helpers;
using SpaceWeather.Models;

namespace SpaceWeather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CelestialBodiesController : ControllerBase
    {
        private static List<CelestialBody> celestialBodies = CelestialBodyDataInitializer.InitializeCelestialBodies();

        private readonly ILogger<CelestialBodiesController> _logger;

        public CelestialBodiesController(ILogger<CelestialBodiesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetCelestialBody(int id)
        {
            var celestialBody = celestialBodies.FirstOrDefault(c => c.Id == id);
            if (celestialBody == null)
            {
                return NotFound();
            }

            return Ok(celestialBody);
        }

        [HttpGet]
        public IActionResult GetCelestialBodies()
        {
            return Ok(celestialBodies);
        }
    }
}
