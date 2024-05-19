using Data.Models;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class SalaryRepository(DatabaseContext context) : BaseRepository<Salary>(context)
    {

       

        public async Task<bool> HasPaid(int empCode, int month)
        {
            return await context.Salaries
                                 .AnyAsync(s => s.Employee.EmployeeCode == empCode && s.Month== month);
        }


        

    }
}
