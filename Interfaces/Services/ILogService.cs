using CalculationUI.Models;
using Model.Core;
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
        void Add(CalculationDto calculationDto);
    }
}
