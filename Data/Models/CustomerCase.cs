using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class CustomerCase : BaseEntity
    {

        [MaxLength(15)]
        
        public string CaseNumber { get; set; } 

        [MaxLength(255)]
        public string Complain { get; set; }

        [MaxLength(255)]
        public string Solution { get; set; }
        [MaxLength(255)]
        public string Notes { get; set; }

        public Customer Customer {  get; set; }

        public Employee Employee { get; set; }

        public CustomerCase()
        {
            // Generate the case number when a new instance of CustomerCase is created
            GenerateCaseNumber();
        }

        private void GenerateCaseNumber()
        {
            // Define the pool of characters to choose from
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";

            // Randomly select characters and digits to form the case number
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 2; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            for (int i = 0; i < 2; i++)
            {
                sb.Append(digits[random.Next(digits.Length)]);
            }
            for (int i = 0; i < 2; i++)
            {
                sb.Append(chars[random.Next(chars.Length)]);
            }
            sb.Append(digits[random.Next(digits.Length)]);
            sb.Append(chars[random.Next(chars.Length)]);

            // Set the generated case number
            CaseNumber = sb.ToString();
        }
    }


}