using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Services;

namespace CustomerCareService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCasesController(CustomerCaseService customerCaseService) : Controller
    {

      

        [HttpPost("AddCase")]
        public async Task<IActionResult> AddCase(CustomerCaseDTO customerCase)
        {

            try
            {
                string caseNumber = await customerCaseService.AddCase(customerCase);
                return Ok($"your case number is {caseNumber}");

            }catch (Exception ex) {

                if (ex is MyNotFoundException)
                {
                    Console.WriteLine("asdfasdf");

                    return NotFound(ex.Message);

                }else if ( ex is InvalidOperationException )
                {
                    
                    return Conflict(ex.Message);

                }

                    Console.WriteLine("asdkjhfgasdjf");


                return Problem(ex.Message, null, 500);
            }


        }
    }
}
