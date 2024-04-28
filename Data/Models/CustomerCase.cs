using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class CustomerCase : BaseEntity
    {

        [MaxLength(15)]
        public string CaseNumber { get; set; }
        
        [MaxLength(15)]
        public string Complain { get; set; }

        [MaxLength(15)]
        public string Solution { get; set; }
        [MaxLength(15)]
        public string Notes { get; set; }

        public Customer Customer {  get; set; }
        

    }
}