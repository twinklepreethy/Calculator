using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface IFunctionFactoryWrapper
    {
        Task<Function> CreateFunctionFactory(FunctionTypeEnum functionType);
        Task<Dictionary<FunctionTypeEnum, Func<Function>>> GetFunctionFactories();
    }

    public class FunctionFactoryWrapper : IFunctionFactoryWrapper
    {
        public async Task<Function> CreateFunctionFactory(FunctionTypeEnum functionType)
        {
            return FunctionFactory.CreateFunctionFactory(functionType);
        }

        public async Task<Dictionary<FunctionTypeEnum, Func<Function>>> GetFunctionFactories()
        {
            return FunctionFactory.GetFunctionFactories();
        }
    }
}
