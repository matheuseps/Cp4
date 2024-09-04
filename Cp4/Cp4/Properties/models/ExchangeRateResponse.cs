using System.Collections.Generic;

namespace Cp4.Models
{
    public class ExchangeRateResponse
    {
        private Dictionary<string, decimal> rates = new Dictionary<string, decimal>();

        public Dictionary<string, decimal> GetRates()
        {
            return rates;
        }

        public void SetRates(Dictionary<string, decimal> value)
        {
            rates = value;
        }
    }
}
