using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Services;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(CustomerService customerService) : ControllerBase
    {

    

        [HttpPost("AddCustomer")]

        public  async Task<IActionResult> AddCustomer(CustomerDTO customer)
        {

            try
            {
                await customerService.AddCustomer(customer);
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

                CustomerDetailDTO customer = await customerService.GetCustomerDetailByPhone(phone);

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
    }
}
