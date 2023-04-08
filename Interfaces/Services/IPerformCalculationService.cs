using CalculationUI.Models;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IPerformCalculationService
    {
        Task<CalculationDto> PerformCalculation(CalculationViewModel calculationViewModel);
    }
}
