using System.Collections.Generic;

namespace Xtramile.Library
{
    public class WeatherResponse
    {
        public List<WeatherVM> Data { get; set; } = null!;
        public WeatherVM Entity { get; set; } = null!;
        public bool Status { get; set; } = true;
        public string? Message { get; set; }
    }
}
