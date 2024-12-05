using Api.Interfaces;
using Api.Interfaces.Models;

namespace Api.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IExchangeRatesService exchangeRatesService;
        private readonly ICoinMarketCapService coinMarketCapService;

        public CryptoService(IExchangeRatesService exchangeRatesService, ICoinMarketCapService coinMarketCapService)
        {
            this.exchangeRatesService = exchangeRatesService;
            this.coinMarketCapService = coinMarketCapService;
        }
        public async Task<CryptoQoute> GetCryptoQoutesAsync(string symbol)
        {
            var symbolQouteInUSD = await coinMarketCapService.GetCryptoQuoteAsync(symbol);
            var exchangeRateBasedOnUSD = await GetExchangeRatesBasedOnUSD();

            var symbolPrice = symbolQouteInUSD.Quote["USD"].Price;
            var allSymbolQuotes = new Dictionary<string, Quote>();

            foreach (var item in exchangeRateBasedOnUSD)
            {
                allSymbolQuotes[item.Key] = new Quote { Price = symbolPrice * item.Value };
            }

            var result = new CryptoQoute { Symbol = symbol.ToUpper(), Quotes = allSymbolQuotes };

            return result;
        }

        private async Task<Dictionary<string, double>> GetExchangeRatesBasedOnUSD()
        {
            var exchangeRateBasedOnEUR = await exchangeRatesService.GetExchangeRatesAsync();
            var exchangeRateBasedOnUSD = new Dictionary<string, double>();

            foreach (var item in exchangeRateBasedOnEUR.Rates)
            {
                exchangeRateBasedOnUSD[item.Key] = item.Value / exchangeRateBasedOnEUR.Rates["USD"];
            }

            return exchangeRateBasedOnUSD;
        }
    }
}
