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
        private readonly IGetCalculationVMService _getCalculationVMService;
        private readonly IPerformCalculationService _performCalculationService;
        private readonly ILogService _logService;

        public CalculationController(IGetCalculationVMService getCalculationVMService, IPerformCalculationService performCalculationService, ILogService logService)
        {
            _getCalculationVMService = getCalculationVMService;
            _performCalculationService = performCalculationService;
            _logService = logService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _getCalculationVMService.GetCalculationVM());
            }
            catch (Exception ex)
            {
                await _logService.LogError("Error building Calculation ViewModel - " + ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<decimal> PerformCalculation(CalculationViewModel calculationViewModel)
        {
            try
            {
                var result = await _performCalculationService.PerformCalculation(calculationViewModel);
                await _logService.Add(result);
                return result.Result;
            }
            catch (Exception ex)
            {
                await _logService.LogError("Error performing calculation - " + ex.Message);
                throw;
            }

        }
    }
}