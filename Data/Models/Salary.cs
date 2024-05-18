namespace Data.Models
{
    public class Salary : BaseEntity
    {

        public DateTime PaidDate { get; set; }

        public int month { get; set; }

        public double totalHour { get; set; }


        public List<EmployeeDailyHours>? DailyHours { get; set; }

        public Employee Employee { get; set; }  

    }
}