using Api.Config;
using Api.Exceptions;
using Api.Interfaces;
using Api.Interfaces.Models;
using Api.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Api.ExternalServices
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly HttpClient _httpClient;
        private readonly ExchangeRateSettings _config;
        private readonly ILogger<ExchangeRatesService> _logger;

        public ExchangeRatesService(HttpClient httpClient, ILogger<ExchangeRatesService> logger, IOptions<ExchangeRateSettings> options)
        {
            this._httpClient = httpClient;
            this._config = options.Value;
            this._logger = logger;
        }

        public async Task<ExchangeRates> GetExchangeRatesAsync()
        {
            var endpoint = $"{_config.Endpoint}?symbols={_config.Symbols}&access_key={_config.ApiKey}";
            var response = await _httpClient.GetAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Request failed with status code {response.StatusCode} in {this.GetType()}");
                throw new HttpRequestException($"{response.RequestMessage} - status code : {response.StatusCode}");
            }

            ExchangeRatesApiResult apiResult = null;
            using (HttpContent content = response.Content)
            {
                string json = await content.ReadAsStringAsync();
                apiResult = JsonConvert.DeserializeObject<ExchangeRatesApiResult>(json);
            }

            if (apiResult is null || !apiResult.Rates.Any())
            {
               throw new NotFoundException("exchange rates not found");
            }

            return new ExchangeRates { Rates = apiResult.Rates };
        }
    }
}
