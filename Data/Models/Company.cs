using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Company : BaseEntity
    {
        public int CompanyCode { get; set; }

       [MaxLength(100)]    
       public string CompanyName { get; set;}

       public List<Office> Offices { get; set; }



    
    }
}
