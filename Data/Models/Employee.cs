using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Employee : BaseEntity
    {

        public int EmployeeId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }


        [MaxLength(100)]
        [EmailAddress]
        public string Email {  get; set; }

        public int HourlyWage {  get; set; }

        public Office Office { get; set; }

        public List<Salary> Salaries { get; set; }

        public List<CustomerCase> CustomerCases { get; set; }




    }
}