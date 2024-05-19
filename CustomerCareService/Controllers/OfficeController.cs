using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTO;
using Shared.Exceptions;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repositories
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController(OfficeService _officeService) : ControllerBase
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
