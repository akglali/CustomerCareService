using Data.Models;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{

    public class OfficeRepository(DatabaseContext context) : BaseRepository<Office>(context), IOfficeRepository
    {


        //check if the office exist
        public async Task<bool> OfficeExist(int OfficeCode)
        {
            return await context.Offices.AnyAsync(o => o.OfficeCode == OfficeCode);
        }


        public async Task<Office?> GetOfficeById(int OfficeCode)
        {
            return await context.Offices.FirstOrDefaultAsync(o => o.OfficeCode == OfficeCode);
        }


        public async Task<List<OfficeDTOWithAllEntities>> GetAllOffice()
        {
            var offices = await context.Offices.Include(o => o.Company).ToListAsync();


            var allOffice = new List<OfficeDTOWithAllEntities>();

            foreach (var office in offices)
            {
                allOffice.Add(new OfficeDTOWithAllEntities()
                {
                    OfficeCode = office.OfficeCode,
                    Name = office.OfficeName,
                    CreatedDate = DateTime.Now,
                    Company = new AddCompanyDTO()
                    {
                        CompanyCode = office.Company.CompanyCode,
                        CompanyName = office.Company.CompanyName,
                    },

                });
            }

            return allOffice;
        }

        public async Task<OfficeDTOWithAllEntities> GetOfficeByCode(int OfficeCode)
        {

            var office = await context.Offices.Include(o => o.Company).FirstOrDefaultAsync(o => o.OfficeCode == OfficeCode);

            return new OfficeDTOWithAllEntities()
            {
                OfficeCode = office.OfficeCode,
                Name = office.OfficeName,
                CreatedDate = DateTime.Now,
                Company = new AddCompanyDTO()
                {
                    CompanyCode = office.Company.CompanyCode,
                    CompanyName = office.Company.CompanyName,
                },
            };

        }
    }
}