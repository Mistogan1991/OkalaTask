using Api.Interfaces;
using Api.Interfaces.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class CryptoController : ControllerBase
    {
        
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        [HttpGet(Name = "GetQuotesBySymbol")]
        public async Task<CryptoQoute> GetQuotesBySymbol(string symbol)
        {
            var res = await _cryptoService.GetCryptoQoutesAsync(symbol);
            return res;
        }
    }
}
