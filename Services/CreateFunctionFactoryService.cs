using Interfaces.Repositories;
using Interfaces.Services;
using Model.Core;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CreateFunctionFactoryService : ICreateFunctionFactoryService
    {
        private readonly ICalculationRepository _calculatorRepository;

        public CreateFunctionFactoryService(ICalculationRepository calculationRepository)
        {
            _calculatorRepository = calculationRepository;
        }

        public Function CreateFunctionFactory(FunctionTypeEnum functionType)
        {
            var functionFactories = _calculatorRepository.GetFunctionFactories();

            if (!functionFactories.TryGetValue(functionType, out var factory))
            {
                throw new ArgumentException("Invalid function type");
            }
            return factory();
        }
    }
}
