using CalculationUI.Models;
using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CalculationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculationController : ControllerBase
    {
        private readonly ILogger<CalculationController> _logger;
        private readonly IGetFunctionsService _getFunctionsService;
        //private readonly ICre

        public CalculationController(ILogger<CalculationController> logger, IGetFunctionsService getFunctionsService)
        {
            _logger = logger;
            _getFunctionsService = getFunctionsService;
        }

        [HttpGet]
        public void Get()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public void SaveFunction(int functionId)
        {

        }
    }
}