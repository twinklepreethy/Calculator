using CalculationUI.Models;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.Core;
using Model.DTOs;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LogService : ILogService
    {
        private readonly ICalculationRepository _calculatorRepository;

        public LogService(ICalculationRepository calculationRepository, ICreateFunctionFactoryService createFunctionFactoryService)
        {
            _calculatorRepository = calculationRepository;
        }

        public void Add(CalculationDto calculationDto)
        {
            var message = $"Date: { calculationDto.Date }";
            _calculatorRepository.Add(message);
        }
    }
}
