using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class DailyHoursRepository (DatabaseContext context) : BaseRepository<EmployeeDailyHours>(context)
    {



        public async Task<bool> EmployeeClockedInCheck(int EmployeeCode)
        {
            // Get the current date in UTC
            DateTime currentDateUtc = DateTime.UtcNow.Date;
           Console.WriteLine(currentDateUtc.ToString(), currentDateUtc);

            var employeeRecord = await context.EmployeesDailyHours
                .Include(e => e.Employee).Where(e=>e.StartTime.ToUniversalTime().Date == currentDateUtc)
                .FirstOrDefaultAsync(e => e.Employee.EmployeeCode == EmployeeCode );

            return employeeRecord != null;
        }

     

        public async Task<EmployeeDailyHours> GetClockedInEmployeeInfo(int EmployeeCode)
        {
            // Get the current date in UTC
            DateTime currentDateUtc = DateTime.UtcNow.Date;

            // Query the database for the employee's record
            var employeeRecord = await context.EmployeesDailyHours
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(e => e.Employee.EmployeeCode == EmployeeCode &&
                                          e.StartTime.ToUniversalTime().Date == currentDateUtc &&
                                          e.EndTime == null); // Check if EndTime is null

            return employeeRecord;
        }


        public async Task<double> GetTotalMonthlyHours(long EmpID, int month)
        {
            // Get the start and end date of the selected month in UTC
            DateTime startDate = new DateTime(DateTime.UtcNow.Year, month, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            // Query the database for all clock-in and clock-out records of the employee within the specified month
            var employeeRecords = await context.EmployeesDailyHours
                .Include(e => e.Employee)
                .Where(e => e.Employee.Id == EmpID &&
                            e.StartTime >= startDate &&
                            e.StartTime <= endDate &&
                            e.EndTime.HasValue)
                .ToListAsync();

            // Calculate the total hours worked
            double totalHours = employeeRecords.Sum(e => (e.EndTime.Value - e.StartTime).TotalHours);

            return totalHours;
        }
    }
}
