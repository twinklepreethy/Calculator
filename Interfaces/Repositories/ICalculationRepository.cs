using Factory;
using Model.DTOs;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repositories
{
    public interface ICalculationRepository
    {
        Task Add(string message);
        Task<Dictionary<FunctionTypeEnum, Func<Function>>> GetFunctionFactories();
    }
}
