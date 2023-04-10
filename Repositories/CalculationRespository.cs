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

        public async Task<Dictionary<FunctionTypeEnum, Func<Function>>> GetFunctionFactories()
        {
            return await _functionFactoryWrapper.GetFunctionFactories();
        }

        public async Task Add(string message, string path)
        {
            try
            {
                DateTime now = DateTime.Now;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.Combine(path, $"log_{now.ToString("yyyy-MM-dd_HH-mm-ss")}.txt");

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Data cannot be logged" + ex.Message);
            }
        }
    }
}