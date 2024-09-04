using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Cp4.Models;

namespace Cp4.Services
{
    public class ConversionRateService : IConversionRate
    {
        private readonly HttpClient _httpClient;

        public ConversionRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetConversionRateAsync(string fromCurrency, string toCurrency)
        {
            var response = await _httpClient.GetAsync($"https://v6.exchangerate-api.com/v6/YOUR_API_KEY/latest/{fromCurrency}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ExchangeRateResponse>();
                if (result?.GetRates() != null && result.GetRates().TryGetValue(toCurrency, out var rate))
                {
                    return rate;
                }
            }
            throw new Exception("Failed to retrieve conversion rate.");
        }
    }
}
