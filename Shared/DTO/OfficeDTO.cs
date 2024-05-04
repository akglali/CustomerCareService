using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class OfficeDTO
    {
        public int OfficeCode { get; set; }
        public string Name { get; set; }

        public int CompanyCode { get; set; }
    }

    public class OfficeDTOWithAllEntities
    {
        public int OfficeCode { get; set; }
        public string Name { get; set; }

        public AddCompanyDTO Company { get; set; }

        public DateTime CreatedDate { get; set; }   

        //public List<CustomerDTO> Customers { get; set; }

    }

}
