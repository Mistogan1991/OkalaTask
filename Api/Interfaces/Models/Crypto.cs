using System.Text.Json.Serialization;

namespace Api.Interfaces.Models
{
    public class Crypto
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("quote")]
        public Dictionary<string, Quote> Quote { get; set; }
    }
}
