using Model.Constants;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    [FunctionType(FunctionTypeEnum.CombinedWith)]
    public class CombinedWithFunction : Function
    {
        public CombinedWithFunction()
        {
            FunctionType = FunctionTypeEnum.CombinedWith;
        }

        public override decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA * probabilityB;
        }

        public override string GetFormula()
        {
            return FunctionFormulaConstants.CombinedWithFunction;
        }
    }
}
