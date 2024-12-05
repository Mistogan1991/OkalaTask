using Api.Models;
using Newtonsoft.Json;

namespace Api.Interfaces.Models
{
    public class ExchangeRatesApiResult
    {
        public bool Success { get; set; }
        public int Timestamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string, double> Rates { get; set; }
    }
}
