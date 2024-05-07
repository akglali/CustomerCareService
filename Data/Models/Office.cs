using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Office : BaseReposityory
    {

        public int OfficeCode { set; get; }

        [MaxLength(100)]
        public string OfficeName { set; get;}

        public Company Company { set; get; }

        public List<Customer>? Customers {  set; get; }

        public List<Employee>? Empoloyees { set; get; }

    }
}
