using System.Text.Json.Serialization;

namespace Api.Interfaces.Models
{
    public class CoinMarketCapApiResult
    {
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, Crypto> Data { get; set; }
    }
}
