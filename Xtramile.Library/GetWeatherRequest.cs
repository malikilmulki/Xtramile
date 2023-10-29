using System.Text.Json.Serialization;

namespace Xtramile.Library
{
    public class GetWeatherRequest
    {
        [JsonPropertyName("q")]
        public string Query { get; set; }

        [JsonPropertyName("appid")]
        public string ApplicationId { get; set; }

        [JsonPropertyName("mode")]
        public string? Mode { get; set; } = null!;

        [JsonPropertyName("units")]
        public string? Units { get; set; } = null!;

        [JsonPropertyName("lang")]
        public string? Lang { get; set; } = null!;
    }
}
