using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Core
{
    public class Function
    {
        public virtual string GetFormula()
        {
            return string.Empty;
        }

        public virtual decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return 0;
        }
    }
}
