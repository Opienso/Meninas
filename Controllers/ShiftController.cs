using Meninas.Entities;
using Meninas.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Meninas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpPost]
        public IActionResult CreateShift([FromBody] CreateShiftDto createShiftDto) {
            string userType = User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;
            if (userType == "sitter")
            {
                Shift shift = new Shift()
                {
                    Date = createShiftDto.Date,
                    Place = createShiftDto.Place,
                    Description = createShiftDto.Description,
                    ClientId = createShiftDto.ClientId,
                    SitterId = createShiftDto.SitterId
                };
                var result = _shiftService.CreateShift(shift);

                if (true)//Esto no es asi
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else {
                return Forbid();
            }
        }
    }

}
