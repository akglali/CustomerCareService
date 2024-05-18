using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Services;

namespace CustomerCareService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyContorller(CompanyService companyService): ControllerBase
    {

        [HttpPost("AddCompany")]  

        public async Task<IActionResult> AddCompany(AddCompanyDTO company)
        {
          try
            {
               await companyService.AddCompany(company);
               return Ok(company);
            }catch (Exception ex)
            {
                if (ex is DuplicateException)
                {
                    return Conflict(ex.Message);
                }

                return Problem(ex.Message, null, 500);
            }

        }

        [HttpGet("CompanyCode")]

        public async Task<IActionResult> GetCompanyByCode(int CompanyCode)
        {
            try{
            
                var company = await companyService.GetCompanyByCode(CompanyCode);
                return Ok(company);

            }
            catch (Exception ex)
            {
                if (ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }
                Problem(ex.Message, null, 500);

            }

            return Ok();


        }


        [HttpGet("AllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var companies = await companyService.GetAllCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while retrieving offices.");
            }
        }
    }
}
