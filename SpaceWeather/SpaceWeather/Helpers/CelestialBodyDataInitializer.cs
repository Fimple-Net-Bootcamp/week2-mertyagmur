using Microsoft.AspNetCore.Mvc;
using SpaceWeather.Models;

namespace SpaceWeather.Helpers
{
    public static class CelestialBodyDataInitializer
    {
        public static List<CelestialBody> InitializeCelestialBodies()
        {
            return new List<CelestialBody>
            {
                new Planet
                {
                    Id = 1,
                    Name = "Earth",
                    Mass = 5.97E24,
                    Gravity = 9.8,
                    WeatherConditions = new List<string> { "Sunny", "Cloudy", "Rainy" }
                },
                new Moon
                {
                    Id = 2,
                    Name = "Moon",
                    Mass = 7.35E22,
                    OrbitRadius = 384400,
                    WeatherConditions = new List<string> { "Clear", "Windy", "Cold" }
                },
                new Planet
                {
                    Id = 3,
                    Name = "Mars",
                    Mass = 6.42E23,
                    Gravity = 3.7,
                    WeatherConditions = new List<string> { "Dust Storms", "Cold", "Clear" }
                },
                new Moon
                {
                    Id = 4,
                    Name = "Europa",
                    Mass = 4.8E22,
                    OrbitRadius = 671034,
                    WeatherConditions = new List<string> { "Ice Storms", "Cold", "Clear" }
                },
            };
        }
    }
}
