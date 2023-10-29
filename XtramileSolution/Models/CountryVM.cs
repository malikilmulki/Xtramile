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

        [JsonPropertyName("provinces")]
        public List<StateVM>? States { get; set; }
    }
    
    public class StateVM
    {
        [JsonPropertyName("province_name")]
        public string StateName { get; set; }

        [JsonPropertyName("cities")]
        public List<CityVM>? Cities { get; set; }

    }

    public class CityVM
    {
        [JsonPropertyName("city_name")]
        public string CityName { get; set; }

    }
}
