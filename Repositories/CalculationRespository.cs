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
        public CalculationRespository()
        {
            
        }

        public async Task<IEnumerable<int>> Get()
        {
            return new List<int> { 1, 2 };
        }

        public async Task<Dictionary<FunctionTypeEnum, Func<Function>>> GetFunctionFactories()
        {
            var functionIds = await Get();

            return FunctionFactory.GetFunctions(functionIds);
        }

        public async Task Add(string message)
        {
            //string message = $"Date: {calculationDto.Date}";
        }
    }
}