using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Repositories;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDailyHourController : ControllerBase
    {

        private readonly EmployeeRepository _employeeRepository;
        private readonly DailyHoursRepository _dailyHoursRepository;
        public EmployeeDailyHourController(EmployeeRepository employeeRepository,DailyHoursRepository dailyHoursRepository)
        {
            _employeeRepository = employeeRepository;
            _dailyHoursRepository=  dailyHoursRepository;
        }

        [HttpPost("ClockIn")]

        public async Task<IActionResult> ClockIn(EmployeeClockInDTO dailyWorkDTO)
        {

            if(!await _employeeRepository.CheckEmployeeExist(dailyWorkDTO.EmployeeCode))
            {
                return BadRequest("There is no such an employee");
            }

            var newSchedule = new EmployeeDailyHours()
            {
                Employee = await _employeeRepository.GetEmployeeByCode(dailyWorkDTO.EmployeeCode), // it can not be null since we check if the employee exist or not
                StartTime = dailyWorkDTO.StartHour.ToUniversalTime(),


            };

            await _dailyHoursRepository.AddAsync(newSchedule);

            return Ok();
        }


        [HttpPost("ClockOut")]
        public async Task<IActionResult> ClockOut(EmployeeClockOutDTO dailyWorkDTO)
        {

            if (!await _employeeRepository.CheckEmployeeExist(dailyWorkDTO.EmployeeCode))
            {
                return BadRequest("There is no such an employee");
            }else if (!await _dailyHoursRepository.EmployeeClockedInCheck(dailyWorkDTO.EmployeeCode))
            {
                    return BadRequest("Employee has not clocked in");
            }

            EmployeeDailyHours employeeRecord = await _dailyHoursRepository.GetClockedInEmployeeInfo(dailyWorkDTO.EmployeeCode);

            Console.WriteLine("asdfsadfasdfasd "+employeeRecord.Id);
            
            employeeRecord.EndTime = dailyWorkDTO.EndTime.ToUniversalTime();

            await _dailyHoursRepository.UpdateAsync(employeeRecord);

            return Ok();
        }


        [HttpGet("GetTotalHour")]

        public async Task<IActionResult> GetTotalHour(int empId, int month)
        {

            var employee = await _employeeRepository.GetEmployeeByCode(empId);

            return Ok(await _dailyHoursRepository.GetTotalMonthlyHours((int)employee.Id,month));
        }
    }
}
