namespace SpaceWeather.Models
{
    public class CelestialBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Mass { get; set; }
        public List<string> WeatherConditions { get; set; } = new List<string>();
    }
}
