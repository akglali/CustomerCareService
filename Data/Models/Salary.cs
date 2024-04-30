namespace Data.Models
{
    public class Salary : BaseEntity
    {

        public DateTime PaidDate { get; set; }

        public Employee Employee { get; set; }  

    }
}