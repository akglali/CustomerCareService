using Data.Models;
using Shared.DTO;

namespace Shared.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<bool> CustomerExist(string Phone);
        Task<Customer?> GetCustomerByPhone(string CustomerPhone);
        Task<CustomerDetailDTO> GetCustomerDetail(string phone);

        Task<List<Customer>> GetAllCustomerByOffice(int OfficeCode);

        Task<Customer> AddAsync(Customer entity);

        IQueryable<Customer> GetAll();

        Task<Customer> GetByIdAsync(long Id);

        Task<Customer> UpdateAsync(Customer entity);

        Task DeleteByIdAsync(long id);


    }
}