using Factory;
using Interfaces.Repositories;
using Model.DTOs;
using Model.Entities;
using Model.Enums;
using System.Reflection;

namespace Repositories
{
    public class CalculationRespository : ICalculationRepository
    {
        private readonly IFunctionFactoryWrapper _functionFactoryWrapper;

        public CalculationRespository(IFunctionFactoryWrapper functionFactoryWrapper)
        {
            _functionFactoryWrapper = functionFactoryWrapper;
        }

        public async Task<IEnumerable<int>> Get()
        {
            return new List<int> { 1, 2 };
        }

        public async Task<Dictionary<FunctionTypeEnum, Func<Function>>> GetFunctionFactories()
        {
            var functionIds = await Get();

            return await _functionFactoryWrapper.GetFunctionFactories();
        }

        public async Task Add(string message)
        {
            //string message = $"Date: {calculationDto.Date}";
        }
    }
}