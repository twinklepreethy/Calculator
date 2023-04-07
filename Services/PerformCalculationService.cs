using CalculationUI.Models;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.Core;
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
        private readonly ICreateFunctionFactoryService _createFunctionFactoryService;
        private readonly ILogService _logService;

        public PerformCalculationService(ICreateFunctionFactoryService createFunctionFactoryService, ILogService logService)
        {
            _createFunctionFactoryService = createFunctionFactoryService;
            _logService = logService;

        }

        public decimal PerformCalculation(CalculationViewModel calculationVM)
        {
            var functionFactory = _createFunctionFactoryService.CreateFunctionFactory((FunctionTypeEnum)calculationVM.SelectedFunctionId);

            if(functionFactory != null)
            {
                var result = functionFactory.Calculate(calculationVM.ProbabilityA, calculationVM.ProbabilityB);

                _logService.Add(new CalculationDto
                {
                    Date = DateTime.Now,
                    ProbabilityA = calculationVM.ProbabilityA,
                    ProbabilityB = calculationVM.ProbabilityB,
                    Function = functionFactory.GetFormula(),
                    Result = result
                });

                return result;
            }

            return 0;
        }
    }
}
