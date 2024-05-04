using Microsoft.EntityFrameworkCore;
using Data.Models;
using Shared.DTO;


namespace Shared.Repositories
{
    public class CompanyRepository (DatabaseContext context): BaseRepository<Company>(context)
    {
      

        public async Task<bool> CompanyExists(int companyCode)
        {
            return await context.Companies.AnyAsync(c => c.CompanyCode == companyCode);

        }


        public async Task<Company?> GetCompanyId(int CompanyCode)
        {
            return await context.Companies.FirstOrDefaultAsync(c => c.CompanyCode == CompanyCode);
        }

        public async Task<CompanyDTO> CompanyByCode(int CompanyCode)
        {

            var company= await context.Companies.Include(c => c.Offices).FirstOrDefaultAsync(c => c.CompanyCode == CompanyCode);

            return new CompanyDTO(){
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
                Offices = company.Offices!.Select(o => new OfficeCompanyDTO{
                    Name=o.OfficeName,
                    OfficeCode= o.OfficeCode, 
                
                }).ToList()
            };
        }

        public async Task<List<CompanyDTO>> GetAllCompanies()
        {

            var companies= await context.Companies.Include(c => c.Offices).ToListAsync();

            var allCompanies = new List<CompanyDTO>();


            foreach(var company in companies)
            {
                allCompanies.Add(new CompanyDTO
                {
                    CompanyCode = company.CompanyCode,
                    CompanyName = company.CompanyName,
                    Offices = company.Offices!.Select(o => new OfficeCompanyDTO
                    {
                        Name = o.OfficeName,
                        OfficeCode = o.OfficeCode,

                    }).ToList()
                });
            }


           
            return allCompanies;

        }
    }
}
