using System.Text.Json.Serialization;

namespace Api.Interfaces.Models
{
    public class Quote
    {
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
