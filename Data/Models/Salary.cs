namespace Data.Models
{
    public class Salary : BaseEntity
    {

        public DateTime PaidDate { get; set; }

        public DateTime StartingPeriod { get; set; }

        public DateTime EndingPeriod { get; set; }
        public List<EmployeeDailyHours>? DailyHours { get; set; }

        public Employee Employee { get; set; }  

    }
}