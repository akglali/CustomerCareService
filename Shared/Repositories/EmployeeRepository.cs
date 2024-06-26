﻿using Data.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class EmployeeRepository(DatabaseContext context) : BaseRepository<Employee>(context), IEmployeeRepository
    {

        public async Task<bool> CheckEmployeeExist(int EmployeeCode)
        {
            return await context.Employees.AnyAsync(e => e.EmployeeCode == EmployeeCode);

        }

        public async Task<Employee?> GetEmployeeByCode(int EmployeeCode)
        {

            return await context.Employees.Include(o => o.Office).FirstAsync(e => e.EmployeeCode == EmployeeCode);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await context.Employees.ToListAsync();
            return employees;
        }
    }
}
