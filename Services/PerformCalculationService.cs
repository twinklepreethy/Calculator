using CalculationUI.Models;
using Factory;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.DTOs;
using Model.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PerformCalculationService : IPerformCalculationService
    {       
        private readonly IFunctionFactoryWrapper _functionFactoryWrapper;

        public PerformCalculationService(IFunctionFactoryWrapper functionFactoryWrapper)
        {
            _functionFactoryWrapper = functionFactoryWrapper;
        }

        public async Task<CalculationDto> PerformCalculation(CalculationViewModel calculationVM)
        {
            var functionFactory = await _functionFactoryWrapper.CreateFunctionFactory((FunctionTypeEnum)calculationVM.SelectedFunctionId);

            if(functionFactory != null)
            {
                var result = functionFactory.Calculate(calculationVM.ProbabilityA, calculationVM.ProbabilityB);

                return new CalculationDto
                {
                    Date = DateTime.Now,
                    ProbabilityA = calculationVM.ProbabilityA,
                    ProbabilityB = calculationVM.ProbabilityB,
                    Function = functionFactory.Formula,
                    Result = result
                };
            }

            return null;
        }
    }
}
