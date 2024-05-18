using Data.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shared.Services
{
    public class SalaryService(DailyHoursRepository _dailyHoursRepository,  SalaryRepository salaryRepository, EmployeeRepository employeeRepository) : ISalaryService
    {

        public double CalculateSalary(double totalHour, double hourlyWage)
        {
            double salary;
            if (totalHour > 160)
            {
                double overtime = (totalHour - 160);

                salary = overtime * (hourlyWage * 1.5) + 160 * hourlyWage;
                return salary;

            }

            salary = hourlyWage * totalHour;

            return salary;
        }
        public async Task MakePaymentForAllEmployees(int month)
        {
            var employees = await employeeRepository.GetAll().ToListAsync();

            foreach (var employee in employees)
            {
                if (!await salaryRepository.HasPaid(employee.EmployeeCode, month))
                {
                    await MakePayment(employee.EmployeeCode, month);

                }
            }
        }

        public async Task MakePayment(int EmpCode, int month)
        {
            var employee = await employeeRepository.GetEmployeeByCode(EmpCode);

            if (employee != null)
            {
                double totalHours = await _dailyHoursRepository.GetTotalMonthlyHours(employee.Id, month);
                if (totalHours > 0)
                {
                    // Assuming we have some logic to calculate the salary based on hours worked
                    double salary = CalculateSalary(totalHours, employee.HourlyWage);

                    // Create a new Salary record
                    var salaryRecord = new Salary
                    {
                        Employee = employee,
                        Month = month,
                        PaidAmount = salary,
                        PaidDate = DateTime.UtcNow,
                        TotalHour = totalHours,
                    };

                    await salaryRepository.AddAsync(salaryRecord);
                }
            }
            else
            {
                throw new MyNotFoundException($"Employee with code {EmpCode} not found.");
            }
        }
    }
}
