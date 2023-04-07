using Model.Core;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICreateFunctionFactoryService
    {
        Function CreateFunctionFactory(FunctionTypeEnum functionType);
    }
}
