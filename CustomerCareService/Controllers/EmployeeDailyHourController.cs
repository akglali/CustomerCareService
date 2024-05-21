using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using Shared.DTO;
using Shared.Services.Interface;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDailyHourController(IEmployeeDailyHoursService _employeeDailyHoursService) : ControllerBase
    {

       
        [HttpPost("ClockIn")]

        public async Task<IActionResult> ClockIn(EmployeeClockInDTO dailyWorkDTO)
        {

            try
            {
                await _employeeDailyHoursService.ClockIn(dailyWorkDTO);
                return Ok();

            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                
               }

                Problem(ex.Message, null, 500);
                return BadRequest(ex.Message);

            }

        }


        [HttpPost("ClockOut")]
        public async Task<IActionResult> ClockOut(EmployeeClockOutDTO dailyWorkDTO)
        {

            try
            {
                await _employeeDailyHoursService.ClockOut(dailyWorkDTO);
                return Ok();

            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    return NotFound(ex.Message);

                }

                Problem(ex.Message, null, 500);
                return BadRequest(ex.Message);

            }

           
        }


        [HttpGet("GetTotalHour")]

        public async Task<IActionResult> GetTotalHour(int empId, int month)
        {

            try
            {
                double totalhours= await _employeeDailyHoursService.GetTotalHour(empId, month);

                return Ok(totalhours);
            }catch (Exception ex)
            {

                if (ex is NotFoundException)
                {
                    return NotFound(ex.Message);

                }

                Problem(ex.Message, null, 500);
                return BadRequest(ex.Message);

            }
        }
    }
}
