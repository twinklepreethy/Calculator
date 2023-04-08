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
            try
            {
                DateTime now = DateTime.Now;

                string directory = @"C:\Logs";
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string fileName = Path.Combine(directory, $"log_{now.ToString("yyyy-MM-dd_HH-mm")}.txt");
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}