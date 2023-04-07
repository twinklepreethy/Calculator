using Model.Constants;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    [FunctionType(FunctionTypeEnum.Either)]
    public class EitherFunction : Function
    {
        public EitherFunction()
        {
            FunctionType = FunctionTypeEnum.Either;
        }

        public override decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA + probabilityB - probabilityA * probabilityB;
        }

        public override string GetFormula()
        {
            return FunctionFormulaConstants.EitherFunction;
        }
    }
}
