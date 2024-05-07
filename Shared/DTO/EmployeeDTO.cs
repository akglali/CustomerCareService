using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class EmployeeDTO
    {

        public int EmployeeCode {  get; set; }

        public string EmployeeName {  get; set; }

        public string EmployeeSurname { get; set; }

        public string EmployeePhoneNumber { get; set; }
        public string EmployeeEmail {  get; set; }

        public int HourlyWage {  get; set; }

        public int OfficeCode { get; set; }
    }

   
}
