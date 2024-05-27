using Data.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Repositories.Interfaces;


namespace Shared.Repositories
{
    public class CustomerCaseRepository(DatabaseContext context) : BaseRepository<CustomerCase>(context), ICustomerCaseRepository
    {


        public async Task<bool> CaseExist(string caseNumber)
        {
            string upperCaseNummber = caseNumber.ToUpper();
            return await context.CustomersCases.AnyAsync(c => c.CaseNumber == upperCaseNummber);

        }

        public async Task<CustomerCase> GetCustomerCaseByCaseNumber(string caseNumber)
        {
            string upperCaseNummber = caseNumber.ToUpper();
            return await context.CustomersCases.Include(e => e.Employee).Include(c => c.Customer).FirstAsync(c => c.CaseNumber == upperCaseNummber);
        }

    }
}
