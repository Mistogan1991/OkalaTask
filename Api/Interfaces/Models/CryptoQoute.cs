namespace Api.Interfaces.Models
{
    public class CryptoQoute
    {
        public string Symbol { get; set; }
        public Dictionary<string, Quote> Quotes { get; set; }
    }
}
