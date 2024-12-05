using Api.Models;

namespace Api.Interfaces
{
    public interface IExchangeRatesService
    {
        Task<ExchangeRates> GetExchangeRatesAsync();
    }
}
