using Data.Models;

namespace Shared.Repositories.Interfaces
{
    public interface ICustomerCaseRepository
    {
        Task<bool> CaseExist(string caseNumber);
        Task<CustomerCase> GetCustomerCaseByCaseNumber(string caseNumber);
    }
}