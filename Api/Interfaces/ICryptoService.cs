using Api.Interfaces.Models;

namespace Api.Interfaces
{
    public interface ICryptoService
    {
        Task<CryptoQoute> GetCryptoQoutesAsync(string? symbol);
    }
}
