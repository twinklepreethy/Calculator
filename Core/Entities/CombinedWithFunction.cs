using Model.Constants;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class CombinedWithFunction : Function
    {
        public override decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA * probabilityB;
        }

        public override string GetFormula()
        {
            return FunctionConstants.CombinedWithFunction;
        }
    }
}
