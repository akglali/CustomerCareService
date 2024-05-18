using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface ICustomerCaseService
    {
        Task<string> AddCase(CustomerCaseDTO customerCase);
    }
}