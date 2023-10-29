using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XtramileSolution.Models
{
    public class CountryVM
    {
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonIgnore]
        public List<string>? States { get; set; }
    }
   

    public class CityVM
    {
        [JsonPropertyName("id")]
        public double Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string CountryCode { get; set; }

        [JsonPropertyName("coord")]
        public CoordinateVM Coordinate { get; set; }

    }

    public class CoordinateVM
    {
        [JsonPropertyName("lon")]
        public decimal? Longitude { get; set; } = null!;
        [JsonPropertyName("lat")]
        public decimal? Latitude { get; set; } = null!;
    }
}
