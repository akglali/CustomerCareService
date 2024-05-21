using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Services.Interface;

namespace Shared.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController(IOfficeService _officeService) : ControllerBase
    {

      
        [HttpPost("AddOffice")]

        public async Task<IActionResult> AddOffice(OfficeDTO office)
        {
            try
            {
                await _officeService.AddOffice(office);
                return Ok();

            }catch (Exception ex)
            {
                if (ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else if (ex is DuplicateException)
                {
                    return Conflict(ex.Message);

                }
                Problem(ex.Message, null, 500);

                return BadRequest(ex.Message);


            }

        }

        [HttpGet("AllOffices")]

        public async  Task<IActionResult> GetAllOffices()
        {
            try { 
                List<OfficeDTOWithAllEntities> offices = await _officeService.GetAllOffices();
                return Ok(offices);
            }
            catch (Exception ex) {
            
                Problem(ex.Message, null, 500);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("OfficeById")]
        

        public async Task<IActionResult> GetOfficeById(int OfficeCode)
        {

            try {

                OfficeDTOWithAllEntities office = await _officeService.GetOfficeByCode(OfficeCode);
                return Ok(office);
            }
            catch (Exception ex) { 
            
                    if (ex is MyNotFoundException)
                {
                    return NotFound(ex.Message);
                }

                    Problem(ex.Message,null,500);
                return BadRequest(ex.Message);
            }

        }

 
    }
}
