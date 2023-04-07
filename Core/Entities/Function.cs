using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public abstract class Function
    {
        public abstract string GetFormula();
        public abstract decimal Calculate(decimal probabilityA, decimal probabilityB);
        public FunctionTypeEnum FunctionType { get; set; }
    }
}
