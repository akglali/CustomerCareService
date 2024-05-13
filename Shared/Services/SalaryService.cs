using Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class SalaryService (DailyHoursRepository _dailyHoursRepository)
    {

        public double CalculateSalary(double totalHour,double hourlyWage)
        {
            double salary ;
            if (totalHour > 160)
            {
                double overtime = (totalHour - 160);

                salary = overtime * (hourlyWage * 1.5) + 160 * hourlyWage;
                return salary;

            }

            salary = hourlyWage * totalHour;

            return salary;
        }
    }
}
