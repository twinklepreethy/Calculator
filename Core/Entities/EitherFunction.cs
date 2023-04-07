using Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class EitherFunction : Function
    {
        public override decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return probabilityA + probabilityB - probabilityA * probabilityB;
        }

        public override string GetFormula()
        {
            return FunctionConstants.EitherFunction;
        }
    }
}
