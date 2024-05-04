using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{


    public class AddCompanyDTO
    {
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }
    }
    public class CompanyDTO
    {
        public int CompanyCode { get; set; }
        public string CompanyName { get; set; }

        public List<OfficeCompanyDTO>? Offices { get; set; }
    }

    public class OfficeCompanyDTO
    {
        public int OfficeCode { get; set; }
        public string Name { get; set; }
    }
}
