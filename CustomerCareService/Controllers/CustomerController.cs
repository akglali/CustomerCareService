using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Repositories;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly OfficeRepository _officeRepository;
        private readonly CustomerRepository _customerRepository;


        public CustomerController(OfficeRepository officeRepository,CustomerRepository customerRepository)
        {
            _officeRepository = officeRepository;
            _customerRepository = customerRepository;
        }

        [HttpPost("AddCustomer")]

        public  async Task<IActionResult> AddCustomer(CustomerDTO customer)
        {
            if(!await _officeRepository.OfficeExist(customer.OfficeCode))
            {
                return BadRequest("There is no such an office");

            }else if (await _customerRepository.CustomerExist(customer.PhoneNumber))
            {
                return Conflict("The Customer Already Exist");

            }

            var office = await  _officeRepository.GetOfficeById(customer.OfficeCode);

            var newCustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CreatedDate = DateTime.UtcNow,
                CustomerEmail=customer.Email,
                CustomerPhone=customer.PhoneNumber,
                Office= office, // it can't be null since we checked if office exist or not
             
            };

            await _customerRepository.AddAsync(newCustomer);

            return Ok();
        }


        [HttpGet("CustomerDetails")]

        public async Task<IActionResult> GetCustomerDetailByPhone(string phone)
        {
            if (!await _customerRepository.CustomerExist(phone))
            {
                return BadRequest("The Customer is not exist");

            }

            var customer= await _customerRepository.GetCustomerDetail(phone);

            return Ok(customer);
        }
    }
}
