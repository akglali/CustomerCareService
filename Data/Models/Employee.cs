using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Employee : BaseReposityory
    {

        public int EmployeeCode { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }


        [MaxLength(100)]
        [EmailAddress]
        public string Email {  get; set; }

        [MaxLength(100)]
        public string PhoneNumber {  get; set; }

        public int HourlyWage {  get; set; }

        public Office Office { get; set; }

        public List<Salary> Salaries { get; set; }

        public List<CustomerCase> CustomerCases { get; set; }






    }
}