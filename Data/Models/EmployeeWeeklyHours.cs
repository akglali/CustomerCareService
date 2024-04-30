using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class EmployeeWeeklyHours 
    {
        public int Id { get; set; }

        public int TotalWeeklyHours { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Employee Employee { get; set; }

        public EmployeeWeeklyHours? WeeklyHours { get; set; }

    }
}
