using Meninas.Entities;
using Meninas.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meninas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitterController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public SitterController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet("GetAvailableShifts")]
        public IActionResult GetAvailableShifts()
        {
            string userType = User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;

            if (userType == "Sitter")
            {
                var availableShifts = _shiftService.GetAvailableShiftsForSitter(userId);

                return Ok(availableShifts);
            }
            else
            {
                return Forbid();
            }
        }
    }
}
