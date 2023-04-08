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
       // private readonly ICreateFunctionFactoryService _createFunctionFactoryService;
        private readonly ILogService _logService;

        public PerformCalculationService(ILogService logService)
        {
            _logService = logService;

        }

        public async Task<decimal> PerformCalculation(CalculationViewModel calculationVM)
        {
            var functionFactory = FunctionFactory.CreateFunctionFactory((FunctionTypeEnum)calculationVM.SelectedFunctionId);

            if(functionFactory != null)
            {
                var result = functionFactory.Calculate(calculationVM.ProbabilityA, calculationVM.ProbabilityB);

                await _logService.Add(new CalculationDto
                {
                    Date = DateTime.Now,
                    ProbabilityA = calculationVM.ProbabilityA,
                    ProbabilityB = calculationVM.ProbabilityB,
                    Function = functionFactory.Formula,
                    Result = result
                });

                return result;
            }

            return 0;
        }
    }
}
