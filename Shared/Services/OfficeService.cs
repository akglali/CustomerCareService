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
    public class OfficeService(OfficeRepository _officeRepository, CompanyRepository _companyRepository) : IOfficeService
    {


        public async Task AddOffice(OfficeDTO office)
        {

            // checking the company and offices  
            if (!await _companyRepository.CompanyExists(office.CompanyCode))
            {
                throw new NotFoundException("There is no such a company");
            }
            else if (await _officeRepository.OfficeExist(office.OfficeCode))
            {
                throw new DuplicateException("Office is already Exist");
            }

            // get the company by its code to add into the office
            var company = await _companyRepository.GetCompanyId(office.CompanyCode);
            var newOffice = new Office()
            {
                OfficeCode = office.OfficeCode,
                OfficeName = office.Name,
                Company = company, // it can't be null since we already check if the companyCode Exist or not

            };
            await _officeRepository.AddAsync(newOffice);

        }

        public async Task<List<OfficeDTOWithAllEntities>> GetAllOffices()
        {

            var offices = await _officeRepository.GetAllOffice();
            return offices;

        }

        public async Task<OfficeDTOWithAllEntities> GetOfficeByCode(int officeCode)
        {
            if (!await _officeRepository.OfficeExist(officeCode))
            {
                throw new NotFoundException($"The office code {officeCode} does not exist");

            }

            OfficeDTOWithAllEntities office = await _officeRepository.GetOfficeByCode(officeCode);

            return office;

        }


    }
}
