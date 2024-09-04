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
        /// Obtém a taxa de câmbio entre duas moedas.
        /// </summary>
        /// <param name="fromCurrency">Moeda de origem (padrão: USD)</param>
        /// <param name="toCurrency">Moeda de destino (padrão: BRL)</param>
        /// <returns>Taxa de câmbio entre as duas moedas.</returns>
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
                return StatusCode(500, "Falha ao recuperar a taxa de câmbio.");
            }
        }
    }
}
