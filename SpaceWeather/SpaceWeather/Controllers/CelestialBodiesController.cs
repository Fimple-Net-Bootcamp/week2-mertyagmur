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

        [HttpPost]
        public IActionResult CreateCelestialBody(CelestialBody celestialBody)
        {
            celestialBody.Id = celestialBodies.Count + 1;
            celestialBodies.Add(celestialBody);
            return CreatedAtAction(nameof(GetCelestialBody), new { id = celestialBody.Id }, celestialBody);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCelestialBody(int id)
        {
            var celestialBody = celestialBodies.FirstOrDefault(c => c.Id == id);
            if (celestialBody == null)
            {
                return NotFound();
            }

            celestialBodies.Remove(celestialBody);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCelestialBody(int id, CelestialBody updatedBody)
        {
            var celestialBody = celestialBodies.FirstOrDefault(c => c.Id == id);
            if (celestialBody == null)
            {
                return NotFound();
            }

            celestialBody.Name = updatedBody.Name;
            celestialBody.Mass = updatedBody.Mass;

            if (celestialBody is Planet planet && updatedBody is Planet updatedPlanet)
            {
                planet.Gravity = updatedPlanet.Gravity;
            }
            else if (celestialBody is Moon moon && updatedBody is Moon updatedMoon)
            {
                moon.OrbitRadius = updatedMoon.OrbitRadius;
            }

            return Ok(celestialBody);
        }
    }
}
