using Model.Core;
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
        IEnumerable<int> Get();
        void Add(string message);
        Dictionary<FunctionTypeEnum, Func<Function>> GetFunctionFactories();
    }
}
