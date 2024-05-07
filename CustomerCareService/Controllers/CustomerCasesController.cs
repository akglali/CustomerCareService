using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Repositories;

namespace CustomerCareService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCasesController : Controller
    {

        public readonly CustomerCaseRepository _customerCaseRepository;
        public readonly EmployeeRepository _employeeRepository;
        public readonly CustomerRepository _customerRepository;

        public CustomerCasesController(CustomerCaseRepository customerCaseRepository, EmployeeRepository employeeRepository, CustomerRepository customerRepository)
        {
            _customerCaseRepository = customerCaseRepository;
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        [HttpPost("AddCase")]
        public async Task<IActionResult> AddCase(CustomerCaseDTO customerCase)
        {

            if (!await _customerRepository.CustomerExist(customerCase.CustomerPhone))
            {
                return BadRequest("Please save the customers detail first then create the case");
            }else if (! await _employeeRepository.CheckEmployeeExist(customerCase.EmployeeId))
            {
                return BadRequest("There is no such an employee");

            }


            var newCase = new CustomerCase() {
                Complain = customerCase.Complain,
                Notes = customerCase.Notes,
                Solution = customerCase.Solution,
                Customer = await _customerRepository.GetCustomerByPhone(customerCase.CustomerPhone),//if the customer is not exist the employee has to create a new customer
                Employee = await _employeeRepository.GetEmployeeByCode(customerCase.EmployeeId),
            
            };


            await _customerCaseRepository.AddAsync(newCase);



            return Ok($"your case number is {newCase.CaseNumber}");
        }
    }
}
