using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    
    public class OfficeRepository(DatabaseContext context) : BaseRepository<Office>(context)
    {

    
        //check if the office exist
        public async Task<bool> OfficeExist(int OfficeCode)
        {
            return await  context.Offices.AnyAsync(O => O.OfficeCode == OfficeCode);
        }
    }
}
