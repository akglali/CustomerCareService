using Data.Models;
using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface IEmployeeService
    {
        Task AddEmployee(EmployeeDTO employee);
        Task<EmployeeDTO?> GetEmployeeByCode(int empCode);
    }
}