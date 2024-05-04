using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {

        private readonly DatabaseContext _databaseContext;

        private readonly OfficeRepository _officeRepository;
        private readonly CompanyRepository _companyRepository;


        public OfficeController(OfficeRepository officeRepository, DatabaseContext databaseContext, CompanyRepository companyRepository)
        {
            _databaseContext = databaseContext;
            _officeRepository = officeRepository;
            _companyRepository = companyRepository;
        }

        [HttpPost("AddOffice")]

        public async Task<IActionResult> AddOffice(OfficeDTO office)
        {

            // checking the company and offices  
            if (!await _companyRepository.CompanyExists(office.CompanyCode))
            {
                return Conflict("There is no such a company");
            }else if ( await _officeRepository.OfficeExist(office.OfficeCode)) 
            {
                return Conflict("Office is already Exist");
            }

            // get the company by its code to add into the office
            var company = await _companyRepository.GetCompanyId(office.CompanyCode);
            var newOffice= new Office()
            {
                OfficeCode = office.OfficeCode,
                OfficeName = office.Name,
                Company = company, // it can't be null since we already check if the companyCode Exist or not

            };
        await _officeRepository.AddAsync(newOffice);

            return Ok();

        }

        [HttpGet("AllOffices")]

        public async  Task<IActionResult> GetAllOffices()
        {
            try
            {
                var offices = await _officeRepository.GetAllOffice();
                return Ok(offices);
            }
            catch (Exception ex)
            {
              
                // Log the exception
                return StatusCode(500, "An error occurred while retrieving offices.");
            }
        }

        [HttpGet("OfficeById")]
        

        public async Task<IActionResult> GetOfficeById(int OfficeCode)
        {

            if(!await _officeRepository.OfficeExist(OfficeCode))
            {
                return Conflict("The office code is not exist");

            }

            var office = await _officeRepository.GetOfficeByCode(OfficeCode);

            return Ok(office);

        }

 
    }
}
