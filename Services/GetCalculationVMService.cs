using CalculationUI.Models;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GetCalculationVMService : IGetCalculationVMService
    {
        private readonly ICalculationRepository _calculationRepository;

        public GetCalculationVMService(ICalculationRepository calculationRepository)
        {
            _calculationRepository = calculationRepository;
        }

        public async Task<CalculationViewModel> GetCalculationVM()
        {
            try
            {
                var functionFactories = await _calculationRepository.GetFunctionFactories();

                return new CalculationViewModel
                {
                    Functions = functionFactories.Select(f => new KeyValueViewModel
                    {
                        Id = (int)f.Key,
                        Text = f.Value().Formula
                    }),
                    Min = CalculationConstants.Min,
                    Max = CalculationConstants.Max,
                    Step = CalculationConstants.Step,
                    ProbabilityAMaxValueErrorMsg = ErrorMessagesConstant.ProbabilityAMaxValueErrorMsg + CalculationConstants.Max,
                    ProbabilityAMinValueErrorMsg = ErrorMessagesConstant.ProbabilityAMinValueErrorMsg + CalculationConstants.Min,
                    ProbabilityBMaxValueErrorMsg = ErrorMessagesConstant.ProbabilityBMaxValueErrorMsg + CalculationConstants.Max,
                    ProbabilityBMinValueErrorMsg = ErrorMessagesConstant.ProbabilityBMinValueErrorMsg + CalculationConstants.Min,
                    EmptyFieldErrorMessage = ErrorMessagesConstant.EmptyFieldErrorMessage
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
