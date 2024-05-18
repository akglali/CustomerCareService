using Data.Models;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Services.Interface;

namespace Shared.Services
{
    public class CustomerCaseService(CustomerCaseRepository _customerCaseRepository, EmployeeRepository _employeeRepository, CustomerRepository _customerRepository) : ICustomerCaseService
    {

        public async Task<string> AddCase(CustomerCaseDTO customerCase)
        {
            if (!await _customerRepository.CustomerExist(customerCase.CustomerPhone))
            {
                throw new MyNotFoundException($"No Customer found with {customerCase.CustomerPhone} phone number please create a customer first.");
            }
            else if (!await _employeeRepository.CheckEmployeeExist(customerCase.EmployeeCode))
            {

                throw new MyNotFoundException($"The employee with {customerCase.EmployeeCode} is not exist");

            }

            // Retrieve the customer and employee entities
            var customer = await _customerRepository.GetCustomerByPhone(customerCase.CustomerPhone);

            var employee = await _employeeRepository.GetEmployeeByCode(customerCase.EmployeeCode);



            // Check if the customer and employee belong to the same office
            if (customer.Office.OfficeCode != employee.Office.OfficeCode)
            {
                throw new InvalidOperationException($"Customer and Employee must belong to the same office. Customer's Office: {customer.Office.OfficeCode}, Employee's Office: {employee.Office.OfficeCode}");
            }


            var newCase = new CustomerCase()
            {
                Complain = customerCase.Complain,
                Notes = customerCase.Notes,
                Solution = customerCase.Solution,
                Customer = await _customerRepository.GetCustomerByPhone(customerCase.CustomerPhone),//if the customer is not exist the employee has to create a new customer
                Employee = await _employeeRepository.GetEmployeeByCode(customerCase.EmployeeCode),

            };


            await _customerCaseRepository.AddAsync(newCase);

            return newCase.CaseNumber;
        }
    }
}
