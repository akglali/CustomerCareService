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
                                          e.StartTime.ToUniversalTime().Date == currentDateUtc);

            return employeeRecord;
        }
    }
}
