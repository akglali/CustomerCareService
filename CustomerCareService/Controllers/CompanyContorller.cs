using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyContorller: ControllerBase
    {


        
        private readonly CompanyRepository _companyRepository;

        public CompanyContorller(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        [HttpPost]  

        public async Task<IActionResult> AddCompany(AddCompanyDTO company)
        {
            if( await _companyRepository.CompanyExists(company.CompanyCode) )
            {
                return Conflict("The company code is exist");
            }

            var newCompany= new Company()
                {
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
            };

            await _companyRepository.AddAsync(newCompany);
            return Ok();

        }

        [HttpGet("CompanyCode")]

        public async Task<IActionResult> GetCompanyByCode(int CompanyCode)
        {
            if (!await _companyRepository.CompanyExists(CompanyCode))
            {
                return Conflict("The company code is not exist");
            }

            var company = await _companyRepository.CompanyByCode(CompanyCode);

            return Ok(company);
        }


        [HttpGet("AllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var companies = await _companyRepository.GetAllCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {

                // Log the exception
                return StatusCode(500, "An error occurred while retrieving offices.");
            }
        }
    }
}
