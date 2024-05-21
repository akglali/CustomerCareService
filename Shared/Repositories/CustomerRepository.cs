using Data.Migrations;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using Shared.DTO;
using Shared.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    public class CustomerRepository(DatabaseContext context) : BaseRepository<Customer>(context), ICustomerRepository
    {

        public async Task<bool> CustomerExist(string Phone)
        {
            return await context.Customers.AnyAsync(c => c.CustomerPhone == Phone);
        }

     

        public async Task<Customer?> GetCustomerByPhone(string CustomerPhone)
        {
            return await context.Customers.Include(c => c.Office).
                FirstAsync(c => c.CustomerPhone == CustomerPhone);
        }

        public async Task<List<Customer>> GetAllCustomerByOffice(int OfficeCode)
        {
            List<Customer> customerList = await GetAll().Include(o=>o.Office).Where(o=> o.Office.OfficeCode == OfficeCode).ToListAsync();

            return customerList;

        }

        public async Task<CustomerDetailDTO> GetCustomerDetail(string phone)
        {

            var customer = await context.Customers.Include(o => o.Office).ThenInclude(c => c.Company).FirstOrDefaultAsync(c => c.CustomerPhone == phone);


            return new CustomerDetailDTO()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.CustomerEmail,
                PhoneNumber = customer.CustomerPhone,
                Office = new OfficeDTOWithAllEntities()
                {
                    Name = customer.Office.OfficeName,
                    OfficeCode = customer.Office.OfficeCode,
                    CreatedDate = customer.Office.CreatedDate,
                    Company = new AddCompanyDTO()
                    {
                        CompanyCode = customer.Office.Company.CompanyCode,
                        CompanyName = customer.Office.Company.CompanyName,
                    }
                }
            };

        }

       

    }
}
