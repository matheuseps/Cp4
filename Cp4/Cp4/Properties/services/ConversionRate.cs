namespace Cp4.Services
{
    public interface IConversionRate
    {
        Task<decimal> GetConversionRateAsync(string fromCurrency, string toCurrency);
    }
}
