using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Services.Interface;

namespace CustomerCareService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCasesController(ICustomerCaseService _customerCaseService) : Controller
    {

      

        [HttpPost("AddCase")]
        public async Task<IActionResult> AddCase(CustomerCaseDTO customerCase)
        {

            try
            {
                string caseNumber = await _customerCaseService.AddCase(customerCase);
                return Ok($"your case number is {caseNumber}");

            }catch (Exception ex) {

                if (ex is MyNotFoundException)
                {

                    return NotFound(ex.Message);

                }else if ( ex is DuplicateException )
                {
                    
                    return Conflict(ex.Message);

                }

                Problem(ex.Message, null, 500);

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCustomerCase")]
        public async Task<IActionResult>  GetCustomerCase(string caseNumber)
        {

            try {
               var customerCase= await _customerCaseService.GetCustomerCase(caseNumber);
                return Ok(customerCase);

            }catch (Exception ex)
            {
                if (ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }

                return Problem(ex.Message, null, 500);

            }


        }
    }
}
