using Model.Constants;
using Model.Enums;
using Model.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    [FunctionType(FunctionTypeEnum.CombinedWith)]
    public class CombinedWithFunction : Function
    {
        public CombinedWithFunction()
        {
            Formula = FunctionFormulaConstants.CombinedWithFunction;
        }

        public override decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA * probabilityB;
        }
    }
}
