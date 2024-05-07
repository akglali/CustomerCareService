using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class WeeklyHoursRepository (DatabaseContext context) : BaseRepository<EmployeeWeeklyHours>(context)
    {

        public async Task<bool> CheckEmployeeWorked(int EmployeeCode)
        {

            // Get the start and end dates of the current week
            DateTime currentDate = DateTime.Today;
            DateTime startDate = currentDate.AddDays(-(int)currentDate.DayOfWeek + (int)DayOfWeek.Monday);
            DateTime endDate = startDate.AddDays(6);

            // Query the database to check if there is any existing record for the employee for the current week
            var existingRecord = await context.EmployeesWeeklyHours.FirstOrDefaultAsync(e => e.Employee.EmployeeCode == EmployeeCode && e.StartDate == startDate);


            if (existingRecord == null)
            {
                return false;
            }
            if (existingRecord != null)
            {
                // Update the total weekly hours
                existingRecord.TotalWeeklyHours += /* Add the hours worked */;
            }
            else
            {
                // Create a new row for the employee with the current week's start and end dates
                var newRecord = new EmployeeWeeklyHours
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalWeeklyHours = 5,
                    Employee = new Employee() { }
                };
                context.EmployeesWeeklyHours.Add(newRecord);


                return true;
        }
    }
}
