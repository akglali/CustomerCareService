using Microsoft.EntityFrameworkCore;
using Data.Models;


namespace Shared.Repositories
{
    public class CompanyRepository: BaseRepository<Company>
    {
        private readonly DatabaseContext _databaseContext;
        public CompanyRepository(DatabaseContext context) : base(context)
        {
            _databaseContext = context;
        }

        public async Task<bool> CompanyExists(int companyCode)
        {
            return await _databaseContext.Companies.AnyAsync(c => c.CompanyCode == companyCode);

        }
    }
}
