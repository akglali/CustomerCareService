using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

using Shared.Services.Interface;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {

     

        [HttpPost("AddEmployee")]

        public async Task<IActionResult> AddEmployee(EmployeeDTO employee)
        {

            try
            {
                await employeeService.AddEmployee(employee);
                return Ok(employee);

            }
            catch (Exception ex)
            {
                if (ex is MyNotFoundException)
                {
                    return base.NotFound(ex.Message);
                }
                else if (ex is DuplicateException)
                {
                    return base.Conflict(ex.Message);

                }

                Problem(ex.Message, null, 500);

                return BadRequest(ex.Message);
            }

        }
        
    }
}
