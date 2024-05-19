using Data.Models;
using SendGrid.Helpers.Errors.Model;
using Shared.DTO;
using Shared.Repositories;
using Shared.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class EmployeeDailyHoursService(EmployeeRepository _employeeRepository, DailyHoursRepository _dailyHoursRepository) : IEmployeeDailyHoursService
    {

        public async Task ClockIn(EmployeeClockInDTO dailyWorkDTO)
        {

            if (!await _employeeRepository.CheckEmployeeExist(dailyWorkDTO.EmployeeCode))
            {
                throw new NotFoundException($"Employee code {dailyWorkDTO.EmployeeCode} does not exist");
            }

            var newSchedule = new EmployeeDailyHours()
            {
                Employee = await _employeeRepository.GetEmployeeByCode(dailyWorkDTO.EmployeeCode), // it can not be null since we check if the employee exist or not
                StartTime = dailyWorkDTO.StartHour.ToUniversalTime(),

            };

            await _dailyHoursRepository.AddAsync(newSchedule);
        }

        public async Task ClockOut(EmployeeClockOutDTO dailyWorkDTO)
        {
            if (!await _employeeRepository.CheckEmployeeExist(dailyWorkDTO.EmployeeCode))
            {
                throw new NotFoundException($"Employee code {dailyWorkDTO.EmployeeCode} does not exist");
            }
            else if (!await _dailyHoursRepository.EmployeeClockedInCheck(dailyWorkDTO.EmployeeCode))
            {
                throw new NotFoundException($"Employee {dailyWorkDTO.EmployeeCode} has not clocked in");

            }

            EmployeeDailyHours employeeRecord = await _dailyHoursRepository.GetClockedInEmployeeInfo(dailyWorkDTO.EmployeeCode);

            employeeRecord.EndTime = dailyWorkDTO.EndTime.ToUniversalTime();

            await _dailyHoursRepository.UpdateAsync(employeeRecord);

        }

        public async Task<double> GetTotalHour(int empId, int month)
        {
            if (!await _employeeRepository.CheckEmployeeExist(empId))
            {
                throw new NotFoundException($"Employee code {empId} does not exist");
            }
            var employee = await _employeeRepository.GetEmployeeByCode(empId);

            double totalHour = await _dailyHoursRepository.GetTotalMonthlyHours((int)employee.Id, month);

            return totalHour;
        }

    }
}
