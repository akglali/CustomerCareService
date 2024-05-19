using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface IEmployeeDailyHoursService
    {
        Task ClockIn(EmployeeClockInDTO dailyWorkDTO);
        Task ClockOut(EmployeeClockOutDTO dailyWorkDTO);
        Task<double> GetTotalHour(int empId, int month);
    }
}