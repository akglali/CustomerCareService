using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class CustomerCaseDTO
    {
        public string? CaseNumber { get; set; } = null;
        public string Complain {  get; set; }
        public string Solution { get; set; }
        public string Notes { get; set; }
        public string CustomerPhone { get; set; }

        public int EmployeeId {  get; set; }
    }
}
