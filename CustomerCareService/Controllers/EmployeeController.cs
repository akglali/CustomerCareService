using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;

using Shared.Services.Interface;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService _employeeService) : ControllerBase
    {

     

        [HttpPost("AddEmployee")]

        public async Task<IActionResult> AddEmployee(EmployeeDTO employee)
        {

            try
            {
                await _employeeService.AddEmployee(employee);
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

        [HttpGet("GetEmployeeInfo")]
        public async Task<IActionResult> GetEmployeeInfo(int empCode)
        {
            try
            {

            var employee = await _employeeService.GetEmployeeByCode(empCode);
                return Ok(employee);
            }catch (Exception ex)
            {
                if (ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }
                Problem(ex.Message, null, 500);

                return BadRequest(ex.Message);
            }
        }
        
    }
}
