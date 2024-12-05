using System.Collections.Generic;
using Api.Interfaces.Models;

namespace Api.Interfaces
{
    public interface ICoinMarketCapService
    {
        Task<SymbolQuote> GetCryptoQuoteAsync(string code);
    }
}
