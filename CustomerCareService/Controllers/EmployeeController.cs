using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Services;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(EmployeeService employeeService) : ControllerBase
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
