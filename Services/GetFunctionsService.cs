using Interfaces.Repositories;
using Interfaces.Services;
using Model.DTOs;
using Model.Entities;

namespace Services
{
    public class GetFunctionsService : IGetFunctionsService
    {
        private readonly ICalculationRepository _calculationRepository;

        public GetFunctionsService(ICalculationRepository calculationRepository)
        {
            _calculationRepository = calculationRepository;
        }

        public IEnumerable<FunctionDto> GetFunctions()
        {
            try
            {
                return _calculationRepository.Get().Select(x => new FunctionDto
                {
                    Id = x,
                    Text = "" //Get from GetFormula() and from enum
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}