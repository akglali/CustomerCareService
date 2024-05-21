using Data.Models;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Services.Interface;

namespace Shared.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly OfficeRepository _officeRepository;
        private readonly CustomerRepository _customerRepository;

        // Constructor initializing dependencies
        public CustomerService(OfficeRepository officeRepository, CustomerRepository customerRepository)
        {
            _officeRepository = officeRepository;
            _customerRepository = customerRepository;
        }
        public async Task AddCustomer(CustomerDTO customer)
        {
            if (!await _officeRepository.OfficeExist(customer.OfficeCode))
            {
                throw new MyNotFoundException($"Office Number {customer.OfficeCode} is not exist");

            }
            else if (await _customerRepository.CustomerExist(customer.PhoneNumber))
            {
                throw new DuplicateException("The Customer Already Exist");
            }

            var office = await _officeRepository.GetOfficeById(customer.OfficeCode);

            var newCustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CreatedDate = DateTime.UtcNow,
                CustomerEmail = customer.Email,
                CustomerPhone = customer.PhoneNumber,
                Office = office, // it can't be null since we checked if office exist or not

            };

            await _customerRepository.AddAsync(newCustomer);

        }

        public async Task<CustomerDetailDTO> GetCustomerDetailByPhone(string phone)
        {
            if (!await _customerRepository.CustomerExist(phone))
            {
                throw new MyNotFoundException($"The Customer {phone} number is not exist");

            }

            var customer = await _customerRepository.GetCustomerDetail(phone);
            return customer;

        }

        public async Task<Customer> DeleteCustomerByPhoneNumber(string phone)
        {
            if (!await _customerRepository.CustomerExist(phone))
            {
                throw new MyNotFoundException($"The Customer {phone} number is not exist");

            }

            Customer? customer = await _customerRepository.GetCustomerByPhone(phone);


            await _customerRepository.DeleteByIdAsync(customer.Id);
            return customer;

        }

        public async Task<List<CustomerDTO>> GetAllCustomerByOfficeCode(int officeCode)
        {


            if (!await _officeRepository.OfficeExist(officeCode)){
                throw new MyNotFoundException($"Office code {officeCode} is not exist");
            }
            List<Customer> customers = await _customerRepository.GetAllCustomerByOffice(officeCode);

            List<CustomerDTO> customersDetail = new List<CustomerDTO>();

            foreach (var customer in customers)
            {
                customersDetail.Add(new CustomerDTO
                    {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.CustomerEmail,
                    PhoneNumber = customer.CustomerPhone,
                    OfficeCode= customer.Office.OfficeCode,
                });
            }

            return customersDetail;

        }


    }
}
