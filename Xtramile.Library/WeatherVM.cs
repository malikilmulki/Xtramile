using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Xtramile.Library
{
    public class WeatherVM
    {
        [JsonPropertyName("coord")]
        public Coordinate? Coordinate { get; set; } = null!;

        [JsonPropertyName("weather")]
        public List<Weather>? Weather { get; set; } = null!;

        [JsonPropertyName("base")]
        public string? Base { get; set; } = null!;

        [JsonPropertyName("main")]
        public Main? Main { get; set; } = null!;

        [JsonPropertyName("visibility")]
        public int? Visibilty { get; set; } = null!;

        [JsonPropertyName("wind")]
        public Wind? Wind { get; set; } = null!;

        [JsonPropertyName("clouds")]
        public Clouds? Clouds { get; set; } = null!;

        [JsonPropertyName("dt")]
        public long? DT { get; set; } = null!;

        [JsonPropertyName("sys")]
        public Sys? Sys { get; set; } = null!;

        [JsonPropertyName("timezone")]
        public long? Timezone { get; set; } = null!;

        
        private string _time;

        public string Time 
        {

            get
            {
                TimeSpan result = TimeSpan.FromSeconds(Convert.ToDouble(Timezone));
                _time = result.ToString("hh':'mm");
                return _time;
            }
            internal set 
            { 
                value = _time ?? value;
            }
        }


        [JsonPropertyName("id")]
        public long? Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string? Name { get; set; } = null!;

        [JsonPropertyName("cod")]
        public int? COD { get; set; } = null!;
    }

    public class Coordinate
    {
        [JsonPropertyName("lon")]
        public decimal? Longitude { get; set; } = null!;
        [JsonPropertyName("lat")]
        public decimal? Latitude { get; set; } = null!;
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("main")]
        public string? Main { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; } = null!;

        [JsonPropertyName("icon")]
        public string? Icon { get; set; } = null!;
    }

    public class Main
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        private double _tempCelcius;
        public double TempCelcius
        {

            get
            {
                _tempCelcius = (Temp - 32) * 5 / 9;
                return _tempCelcius;
            }
            internal set
            {
                value = _tempCelcius;
            }
        }

        [JsonPropertyName("feels_like")]
        public decimal? FeelsLike { get; set; } = null!;

        [JsonPropertyName("temp_min")]
        public decimal? TempMin { get; set; } = null!;

        [JsonPropertyName("temp_max")]
        public decimal? TempMax { get; set; } = null!;

        [JsonPropertyName("pressure")]
        public int? PRessure { get; set; } = null!;

        [JsonPropertyName("humidity")]
        public int? Humidity { get; set; } = null!;
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public decimal? Spped { get; set; } = null!;

        [JsonPropertyName("deg")]
        public int? Deg { get; set; } = null!;
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public int? All { get; set; } = null!;
    }

    public class Sys
    {
        [JsonPropertyName("type")]
        public int? Type { get; set; } = null!;

        [JsonPropertyName("id")]
        public int? Id { get; set; } = null!;

        [JsonPropertyName("country")]
        public string? Country { get; set; } = null!;

        [JsonPropertyName("sunrise")]
        public long? Sunrise { get; set; } = null!;

        [JsonPropertyName("sunset")]
        public long? Sunset { get; set; } = null!;
    }

}
