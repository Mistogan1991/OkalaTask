namespace Api.Config
{
    public class ExchangeRateSettings
    {
        public required string BaseUrl { get; set; }
        public required string Endpoint { get; set; }
        public required string ApiKey { get; set; }
        public required string Symbols { get; set; }
    }
}
