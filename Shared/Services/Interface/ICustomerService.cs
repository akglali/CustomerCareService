using Data.Models;
using Shared.DTO;

namespace Shared.Services.Interface
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerDTO customer);
        Task<CustomerDetailDTO> GetCustomerDetailByPhone(string phone);

        Task<Customer> DeleteCustomerByPhoneNumber(string phone);
        Task<List<CustomerDTO>> GetAllCustomerByOfficeCode(int OfficeCode);
    }
}