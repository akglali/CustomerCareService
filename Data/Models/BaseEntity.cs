using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } =DateTime.Now;
    }
}
