using Api.Config;
using Api.Controllers;
using Api.Exceptions;
using Api.Interfaces;
using Api.Interfaces.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Api.ExternalServices
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        private readonly ILogger<CoinMarketCapService> _logger;
        private readonly HttpClient _httpClient;
        private readonly CoinMarketCapApiSettings _config;

        public CoinMarketCapService(HttpClient httpClient,
            ILogger<CoinMarketCapService> logger,
            IOptions<CoinMarketCapApiSettings> options)
        {
            _httpClient = httpClient;
            _config = options.Value;
            _logger = logger;
        }

        public async Task<SymbolQuote> GetCryptoQuoteAsync(string code)
        {
            var endpoint = $"{_config.Endpoint}?symbol={code.ToUpper()}&CMC_PRO_API_KEY={_config.ApiKey}";
            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Request failed with status code {response.StatusCode} in {this.GetType()}");
                throw new HttpRequestException($"{response.RequestMessage} - status code : {response.StatusCode}");
            }

            CoinMarketCapApiResult apiResult = null;
            using (HttpContent content = response.Content)
            {
                string json = await content.ReadAsStringAsync();
                apiResult = JsonConvert.DeserializeObject<CoinMarketCapApiResult>(json);
            }

            if (apiResult is null || !apiResult.Data.Any())
            {
                throw new NotFoundException("symbol not found");
            }

            return new SymbolQuote { Quote = apiResult.Data[code.ToUpper()].Quote };
        }
    }
}
