using Model.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal RoundTo4Places(this decimal value)
        {
            return Math.Round(value, CalculationConstants.DecimalPrecision);
        }
    }
}
