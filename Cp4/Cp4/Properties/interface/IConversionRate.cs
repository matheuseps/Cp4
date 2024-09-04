using System.Threading.Tasks;
using Cp4.Models;
using Cp4.Properties.HttpObjetcs; // Ajuste para o namespace correto

namespace Cp4.Interfaces
{
    public interface IConversionRate
    {
        Task<ExchangeRateResponse> GetUsdRateAsync();
    }
}
