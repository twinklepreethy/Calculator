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
        private readonly IValidationService _validationService;
        private readonly ILogService _logService;

        public CalculationController(IGetCalculationVMService getCalculationVMService, IPerformCalculationService performCalculationService, IValidationService validationService, ILogService logService)
        {
            _getCalculationVMService = getCalculationVMService;
            _performCalculationService = performCalculationService;
            _validationService = validationService;
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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PerformCalculation(CalculationViewModel calculationViewModel)
        {
            try
            {
                if((await _validationService.ValidateInputData(calculationViewModel)))
                {
                    var result = await _performCalculationService.PerformCalculation(calculationViewModel);
                    await _logService.Add(result);
                    return Ok(result.Result);
                }

                await _logService.LogError("Invalid Input");
                return BadRequest();
            }
            catch (Exception ex)
            {
                await _logService.LogError("Error performing calculation - " + ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}