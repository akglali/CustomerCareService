using Data.Models;
using Shared.Repositories;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class MockSalaryService : ISalaryService
    {
        List<Employee> employees = new List<Employee>() { 
        new Employee() { Id = 1,
        Email="aspdoi"}
        };
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

        public async Task MakePayment(int EmpCode, int month)
        {
            var employee = employees.Where(a => a.EmployeeCode == EmpCode).First();

        }

        public Task MakePaymentForAllEmployees(int month)
        {
            throw new NotImplementedException();
        }
    }
}
