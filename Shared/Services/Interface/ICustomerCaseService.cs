using Data.Models;
using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface ICustomerCaseService
    {
        Task<string> AddCase(CustomerCaseDTO customerCase);
        Task<CustomerCaseDTO> GetCustomerCase(string caseNumber);

       

    }
}