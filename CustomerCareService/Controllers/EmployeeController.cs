using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Repositories;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeRepository _employeeRepository;

        private readonly OfficeRepository _officeRepository;

        public EmployeeController( EmployeeRepository employeeRepository, OfficeRepository officeRepository)
        {
            _employeeRepository = employeeRepository;
            _officeRepository = officeRepository;
        }


        [HttpPost("AddEmployee")]

        public async Task<IActionResult> AddEmployee(EmployeeDTO employee)
        {

            if (!await _officeRepository.OfficeExist(employee.OfficeCode)){
                return BadRequest("There is no office with that code");
            }
            else if (await _employeeRepository.CheckEmployeeExist(employee.EmployeeCode))
            {
                return Conflict("The employee code is alredy assigned");
            }

            var newEmployee = new Employee()
            {
                EmployeeCode = employee.EmployeeCode,
                Name = employee.EmployeeName,
                Surname = employee.EmployeeSurname,
                Email = employee.EmployeeEmail,
                PhoneNumber=employee.EmployeePhoneNumber,
                HourlyWage = employee.HourlyWage,
                Office = await _officeRepository.GetOfficeById(employee.OfficeCode), // can not be null since we checked it before
            };

            await _employeeRepository.AddAsync(newEmployee);

            return Ok();

        }
        
    }
}
