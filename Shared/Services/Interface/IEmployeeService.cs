using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface IEmployeeService
    {
        Task AddEmployee(EmployeeDTO employee);
    }
}