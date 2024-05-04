using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email {  get; set; }

        public int OfficeCode { get; set; }   

    }


    public class CustomerDetailDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public OfficeDTOWithAllEntities Office { get; set; }

        //public List<CustomerCaseDTO> CustomerCases {get;set;}
    }
}
