using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface ICompanyService
    {
        Task AddCompany(AddCompanyDTO company);
        Task<List<CompanyDTO>> GetAllCompanies();
        Task<CompanyDTO> GetCompanyByCode(int companyCode);
    }
}