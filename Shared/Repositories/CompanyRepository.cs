using Microsoft.EntityFrameworkCore;
using Data.Models;
using Shared.DTO;


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


        public async Task<Company?> GetCompanyId(int CompanyCode)
        {
            return await _databaseContext.Companies.FirstOrDefaultAsync(c => c.CompanyCode == CompanyCode);
        }

        public async Task<CompanyDTO> CompanyByCode(int CompanyCode)
        {

            var company= await _databaseContext.Companies.Include(c => c.Offices).FirstOrDefaultAsync(c => c.CompanyCode == CompanyCode);

            return new CompanyDTO(){
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
                Offices = company.Offices!.Select(o => new OfficeCompanyDTO{
                    Name=o.OfficeName,
                    OfficeCode= o.OfficeCode, 
                
                }).ToList()
            };
            

        }
    }
}
