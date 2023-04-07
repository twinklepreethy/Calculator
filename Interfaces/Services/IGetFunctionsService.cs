using Model.DTOs;

namespace Interfaces.Services
{
    public interface IGetFunctionsService
    {
        IEnumerable<FunctionDto> GetFunctions();
    }
}