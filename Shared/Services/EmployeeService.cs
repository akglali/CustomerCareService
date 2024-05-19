using Data.Models;
using SendGrid.Helpers.Errors.Model;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Repositories;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class EmployeeService(EmployeeRepository _employeeRepository, OfficeRepository _officeRepository) : IEmployeeService
    {


        public async Task AddEmployee(EmployeeDTO employee)
        {

            if (!await _officeRepository.OfficeExist(employee.OfficeCode))
            {
                throw new NotFoundException("There is no office with that code");
            }
            else if (await _employeeRepository.CheckEmployeeExist(employee.EmployeeCode))
            {
                throw new DuplicateException($"The employee {employee.EmployeeCode} code is alredy assigned");
            }

            var newEmployee = new Employee()
            {
                EmployeeCode = employee.EmployeeCode,
                Name = employee.EmployeeName,
                Surname = employee.EmployeeSurname,
                Email = employee.EmployeeEmail,
                PhoneNumber = employee.EmployeePhoneNumber,
                HourlyWage = employee.HourlyWage,
                Office = await _officeRepository.GetOfficeById(employee.OfficeCode), // can not be null since we checked it before
            };

            await _employeeRepository.AddAsync(newEmployee);
        }
    }
}
