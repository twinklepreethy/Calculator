using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class CalculationDto
    {
        public DateTime Date { get; set; }
        public string Function { get; set; }
        public decimal ProbabilityA { get; set; }
        public decimal ProbabilityB { get; set; }
        public decimal Result { get; set; }
    }
}
