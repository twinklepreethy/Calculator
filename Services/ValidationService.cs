using CalculationUI.Models;
using Interfaces.Services;
using Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ValidationService : IValidationService
    {
        private readonly ILogService _logService;
        public ValidationService(ILogService logService)
        {
            _logService = logService;
        }

        public async Task<bool> ValidateInputData(CalculationViewModel calculationViewModel)
        {
            if(calculationViewModel == null) return false;

            if(calculationViewModel.ProbabilityA > CalculationConstants.Max)
            {
                await _logService.LogError(ErrorMessagesConstant.ProbabilityAMaxValueErrorMsg);
                return false;
            }
            else if (calculationViewModel.ProbabilityB > CalculationConstants.Max)
            {
                await _logService.LogError(ErrorMessagesConstant.ProbabilityBMaxValueErrorMsg);
                return false;
            }
            else if (calculationViewModel.ProbabilityA < CalculationConstants.Min)
            {
                await _logService.LogError(ErrorMessagesConstant.ProbabilityAMinValueErrorMsg);
                return false;
            }
            else if (calculationViewModel.ProbabilityB < CalculationConstants.Min)
            {
                await _logService.LogError(ErrorMessagesConstant.ProbabilityBMinValueErrorMsg);
                return false;
            }
            else if(calculationViewModel.SelectedFunctionId == CalculationConstants.EmptyFunction)
            {
                await _logService.LogError(ErrorMessagesConstant.InvalidFunctionSelectedErrorMsg);
                return false;
            }

            return true;
        }
    }
}
