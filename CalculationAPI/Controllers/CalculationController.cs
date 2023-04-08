using CalculationUI.Models;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Model.Constants;

namespace CalculationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly ILogger<CalculationController> _logger;
        private readonly IGetCalculationVMService _getCalculationVMService;
        private readonly IPerformCalculationService _performCalculationService;

        public CalculationController(ILogger<CalculationController> logger, IGetCalculationVMService getCalculationVMService, IPerformCalculationService performCalculationService)
        {
            _logger = logger;
            _getCalculationVMService = getCalculationVMService;
            _performCalculationService = performCalculationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _getCalculationVMService.GetCalculationVM());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<decimal> PerformCalculation(CalculationViewModel calculationViewModel)
        {
            var result = await _performCalculationService.PerformCalculation(calculationViewModel);

            return result;
        }
    }
}