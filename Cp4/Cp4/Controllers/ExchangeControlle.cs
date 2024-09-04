using Cp4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cp4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly IConversionRate _conversionRateService;

        public ExchangeController(IConversionRate conversionRateService)
        {
            _conversionRateService = conversionRateService;
        }

        /// <summary>
        /// Obt�m a taxa de c�mbio entre duas moedas.
        /// </summary>
        /// <param name="fromCurrency">Moeda de origem (padr�o: USD)</param>
        /// <param name="toCurrency">Moeda de destino (padr�o: BRL)</param>
        /// <returns>Taxa de c�mbio entre as duas moedas.</returns>
        [HttpGet("rate")]
        public async Task<IActionResult> GetRate(string fromCurrency = "USD", string toCurrency = "BRL")
        {
            try
            {
                var rate = await _conversionRateService.GetConversionRateAsync(fromCurrency, toCurrency);
                return Ok(rate);
            }
            catch
            {
                return StatusCode(500, "Falha ao recuperar a taxa de c�mbio.");
            }
        }
    }
}
