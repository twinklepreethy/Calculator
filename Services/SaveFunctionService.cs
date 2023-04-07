using CalculationUI.Models;
using Interfaces.Repositories;
using Interfaces.Services;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SaveFunctionService : ISaveFunctionService
    {
        private readonly ICalculationRepository _calculatorRepository;

        public SaveFunctionService(ICalculationRepository calculationRepository)
        {
            _calculatorRepository = calculationRepository;
        }

        public void SaveFunction(CalculationViewModel calculationVM)
        {
            var calculationDto = new CalculationDto
            {
                Date = DateTime.Now,
                Function = calculationVM.SelectedFunctionId.ToString(), //TODO this needs to be text, get it from id
                ProbabilityA = calculationVM.ProbabilityA,
                ProbabilityB = calculationVM.ProbabilityB,
                Result = calculationVM.Value
            };
            _calculatorRepository.Save(calculationDto);
        }
    }
}
