using CalculationUI.Models;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfigurationService _configurationService;

        public LogService(ICalculationRepository calculationRepository, IConfigurationService configurationService)
        {
            _calculatorRepository = calculationRepository;
            _configurationService = configurationService;
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

                await _calculatorRepository.Add(message, _configurationService.GetLogFilePath());
            }
            catch (Exception ex)
            {
                await LogError("Error logging calculation" + ex.Message);
            }
        }

        public async Task LogError(string message)
        {
            await _calculatorRepository.Add($"Error: " + message, _configurationService.GetLogFilePath());
        }
    }
}
