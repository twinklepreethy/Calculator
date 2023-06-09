﻿using CalculationUI.Models;
using Factory;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.Constants;
using Model.DTOs;
using Model.Entities;
using Model.Enums;
using Model.Extensions;
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
        private readonly ILogService _logService;

        public PerformCalculationService(IFunctionFactoryWrapper functionFactoryWrapper, ILogService logService)
        {
            _functionFactoryWrapper = functionFactoryWrapper;
            _logService = logService;
        }

        public async Task<CalculationDto> PerformCalculation(CalculationViewModel calculationVM)
        {
            try
            {
                var functionFactory = await _functionFactoryWrapper.CreateFunctionFactory((FunctionTypeEnum)calculationVM.SelectedFunctionId);

                if (functionFactory != null)
                {
                    var result = functionFactory.Calculate(calculationVM.ProbabilityA, calculationVM.ProbabilityB);

                    return new CalculationDto
                    {
                        Date = DateTime.Now,
                        ProbabilityA = calculationVM.ProbabilityA,
                        ProbabilityB = calculationVM.ProbabilityB,
                        Function = functionFactory.Formula,
                        Result = result.RoundTo4Places()
                    };
                }

                await _logService.LogError("Cannot build function factory");

                return null;
            }
            catch (Exception ex)
            {
                await _logService.LogError("Cannot perform calculation" + ex.Message);
                throw;
            }

        }
    }
}
