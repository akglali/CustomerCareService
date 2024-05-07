using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public abstract class BaseReposityory
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; } =DateTime.UtcNow;
    }
}
