using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class EmployeeDailyHours: BaseEntity
    {

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public Employee Employee { get; set; }


    }
}
