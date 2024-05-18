namespace Data.Models
{
    public class Salary : BaseEntity
    {

        public DateTime PaidDate { get; set; }

        public int Month { get; set; }

        public double TotalHour { get; set; }

        public double PaidAmount { get; set; }


        public List<EmployeeDailyHours>? DailyHours { get; set; }

        public Employee Employee { get; set; }  

    }
}