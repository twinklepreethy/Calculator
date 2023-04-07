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

        public CalculationViewModel GetCalculationVM()
        {
            try
            {
                var functionFactories = _calculationRepository.GetFunctionFactories();

                return new CalculationViewModel
                {
                    Functions = functionFactories.Select(f => new KeyValueViewModel
                    {
                        Id = (int)f.Key,
                        Text = f.Value().GetFormula()
                    }),
                    Min = CalculationConstants.Min,
                    Max = CalculationConstants.Max,
                    Step = CalculationConstants.Step
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
