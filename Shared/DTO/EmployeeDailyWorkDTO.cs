using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class EmployeeClockInDTO
    {
        public int EmployeeCode { get; set; }

        public DateTime StartHour { get; set; }
    }

    public class EmployeeClockOutDTO
    {
        public int EmployeeCode { get; set; }

        public DateTime EndTime { get; set; }
    }

  
}
