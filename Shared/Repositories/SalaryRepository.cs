using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class SalaryRepository(DatabaseContext context) : BaseRepository<Salary>(context)
    {


    }
}
