using CalculationUI.Models;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ILogService
    {
        Task Add(CalculationDto calculationDto);
        Task LogError(string message);
    }
}
