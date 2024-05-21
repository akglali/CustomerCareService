using Data.Models;
using Shared.DTO;

namespace Shared.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<CompanyDTO> CompanyByCode(int CompanyCode);
        Task<bool> CompanyExists(int companyCode);
        Task<List<CompanyDTO>> GetAllCompanies();
        Task<Company?> GetCompanyId(int CompanyCode);

        Task<Company> AddAsync(Company entity);

        IQueryable<Company> GetAll();

        Task<Company> GetByIdAsync(long Id);

        Task<Company> UpdateAsync(Company entity);
    }
}