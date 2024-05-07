namespace Data.Models
{
    public class Salary : BaseReposityory
    {

        public DateTime PaidDate { get; set; }

        public DateTime StartingPeriod { get; set; }

        public DateTime EndingPeriod { get; set; }
        public List<EmployeeWeeklyHours>? WeeklyHours { get; set; }

        public Employee Employee { get; set; }  

    }
}