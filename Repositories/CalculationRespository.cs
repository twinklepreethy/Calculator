using Interfaces.Repositories;
using Model.DTOs;
using Model.Entities;

namespace Repositories
{
    public class CalculationRespository : ICalculationRepository
    {
        public IEnumerable<int> Get()
        {
            return new[] { 1, 2 };
        }

        public void Save(CalculationDto calculationDto)
        {
            var result = new Calculation
            {
                Date = calculationDto.Date,
                Function = calculationDto.Function,
                ProbabilityA = calculationDto.ProbabilityA,
                ProbabilityB = calculationDto.ProbabilityB,
                Result = calculationDto.Result
            };
        }
    }
}