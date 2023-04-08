using Model.Attributes;
using Model.Constants;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    [FunctionType(FunctionTypeEnum.Either)]
    public class EitherFunction : Function
    {         
        public override decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA + probabilityB - probabilityA * probabilityB;
        }
    }
}
