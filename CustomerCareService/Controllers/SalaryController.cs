using Microsoft.AspNetCore.Mvc;
using Shared.Exceptions;
using Shared.Services.Interface;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController(ISalaryService salaryService) : ControllerBase
    {
        [HttpPost("MakePaymentForAllEmployees")]
        public async Task<IActionResult> MakePaymentForAllEmployees(int month)
        {
            try
            {
                await salaryService.MakePaymentForAllEmployees(month);

            }
            catch (Exception ex)
            {
                Problem(ex.Message, null, 500);
            }
            return Ok();
        }

        [HttpPost("MakePaymentEmployee")]

        //check this out
        public async Task<IActionResult> MakePaymentForEmployee(int EmpCode, int month)
        {
            try
            {
                await salaryService.MakePayment(EmpCode, month);
            }
            catch (Exception ex)
            {
                if (ex is MyNotFoundException)
                {
                   return NotFound(ex.Message);
                }
                
                Problem(ex.Message, null, 500);
            }
            return Ok();
        }


    }
}

