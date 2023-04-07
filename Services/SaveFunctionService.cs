using Interfaces.Repositories;
using Interfaces.Services;
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

        public void SaveFunction()
        {
            throw new NotImplementedException();
        }
    }
}
