namespace Api.Config
{
    public class CoinMarketCapApiSettings
    {
        public required string BaseUrl { get; set; }
        public required string Endpoint { get; set; }
        public required string ApiKey { get; set; }
    }
}
