using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Function
    {
        //TODO set it when reading from file and call it in the get formula func
        public string Formula { get; set; } = string.Empty;

        public virtual decimal Calculate(decimal probabilityA, decimal probabilityB)
        {
            return 0;
        }
    }
}
