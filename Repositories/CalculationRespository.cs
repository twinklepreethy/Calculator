using Interfaces.Repositories;

namespace Repositories
{
    public class CalculationRespository : ICalculationRepository
    {
        public IEnumerable<int> Get()
        {
            return new[] { 1, 2 };
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}