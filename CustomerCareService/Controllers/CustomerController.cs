using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Services;
using Shared.Services.Interface;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        // Constructor should use the interface type ICustomerService
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }



        [HttpPost("AddCustomer")]

        public  async Task<IActionResult> AddCustomer(CustomerDTO customer)
        {

            try
            {
                await _customerService.AddCustomer(customer);
                return Ok();

            }
            catch (Exception ex)
            {
                if(ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }else if(ex is DuplicateException)
                {
                    return Conflict(ex.Message);

                }

                Problem(ex.Message,null,500);

                return BadRequest();

            }

        }


        [HttpGet("CustomerDetails")]

        public async Task<IActionResult> GetCustomerDetailByPhone(string phone)
        {
            try
            {

                CustomerDetailDTO customer = await _customerService.GetCustomerDetailByPhone(phone);

                return Ok(customer);

            }
            catch (Exception ex)
            {

                if(ex is MyNotFoundException)
                {
                    return base.NotFound(ex.Message);
                }
                Problem(ex.Message, null,500);
            }
            
            return Ok();

        }

        [HttpPost("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(string phone)
        {
            try
            {
               Customer customer = await _customerService.DeleteCustomerByPhoneNumber(phone);
                return Ok($"The customer {customer.FirstName +" " + customer.LastName} has been deleted.");

            }
            catch (Exception ex)
            {
                if (ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }

                Problem(ex.Message, null,500);
                return BadRequest();
                

            }
        }
        

        [HttpGet("GetCustomerByOffice")]
        public async Task<IActionResult> GetAllCustomerByOffice(int officeCode)
        {

            try
            {
                var customers= await _customerService.GetAllCustomerByOfficeCode(officeCode);
                return Ok(customers);
            }catch (Exception ex)
            {

                if (ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }
                Problem(ex.Message, null,500);
                return BadRequest();
            }

        }
    }
}
