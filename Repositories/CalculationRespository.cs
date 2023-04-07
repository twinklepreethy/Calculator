using Interfaces.Repositories;
using Model.Core;
using Model.DTOs;
using Model.Entities;
using Model.Enums;
using System.Reflection;

namespace Repositories
{
    public class CalculationRespository : ICalculationRepository
    {
        public IEnumerable<int> Get()
        {
            return new List<int> { 1, 2 };
        }

        public Dictionary<FunctionTypeEnum, Func<Function>> GetFunctionFactories()
        {
            var functionIds = Get();

            var functionFactories = new Dictionary<FunctionTypeEnum, Func<Function>>();

            foreach (var id in functionIds)
            {
                var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.IsSubclassOf(typeof(Function)) && t.GetCustomAttribute<FunctionTypeAttribute>()?.FunctionType == (FunctionTypeEnum)id);

                var function = type != null ? Activator.CreateInstance(type) as Function : null;
                functionFactories.Add((FunctionTypeEnum)id, () => function);
            }
            
            return functionFactories;
        }

        public void Add(string message)
        {
            //string message = $"Date: {calculationDto.Date}";
        }
    }
}