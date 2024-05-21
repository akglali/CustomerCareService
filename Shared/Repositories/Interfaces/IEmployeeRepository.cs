using Data.Models;

namespace Shared.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> CheckEmployeeExist(int EmployeeCode);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeByCode(int EmployeeCode);


        Task<Employee> AddAsync(Employee entity);

        IQueryable<Employee> GetAll();

        Task<Employee> GetByIdAsync(long Id);

        Task<Employee> UpdateAsync(Employee entity);

        Task DeleteByIdAsync(long id);
    }
}