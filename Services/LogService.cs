using CalculationUI.Models;
using Interfaces.Repositories;
using Interfaces.Services;
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

        public LogService(ICalculationRepository calculationRepository)
        {
            _calculatorRepository = calculationRepository;
        }

        public async Task Add(CalculationDto calculationDto)
        {
            try
            {
                var message = $"Date: { calculationDto.Date },\n" +
                              $"Caculation Type: { calculationDto.Function },\n" +
                              $"Inputs: P(A): { calculationDto.ProbabilityA } and " +
                              $"P(B): { calculationDto.ProbabilityB },\n" +
                              $"Result: { calculationDto.Result }";

            await _calculatorRepository.Add(message);
            }
            catch (Exception ex)
            {
                await LogError("Error logging calculation");
            }
        }

        public async Task LogError(string message)
        {
            await _calculatorRepository.Add($"Error: " + message);
        }
    }
}
