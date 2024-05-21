using Data.Models;

namespace Shared.Repositories.Interfaces
{
    public interface IDailyHoursRepository
    {
        Task<bool> EmployeeClockedInCheck(int EmployeeCode);
        Task<EmployeeDailyHours> GetClockedInEmployeeInfo(int EmployeeCode);
        Task<double> GetTotalMonthlyHours(long EmpID, int month);

        Task<EmployeeDailyHours> AddAsync(EmployeeDailyHours entity);

        IQueryable<EmployeeDailyHours> GetAll();

        Task<EmployeeDailyHours> GetByIdAsync(long Id);

        Task<EmployeeDailyHours> UpdateAsync(EmployeeDailyHours entity);

        Task DeleteByIdAsync(long id);
    }
}