﻿using Meninas.Entities;
using Meninas.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meninas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForbidResult : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ForbidResult(IShiftService shiftService) { 
         _shiftService = shiftService;
        }
        [HttpPost("TakeShift/{shiftId}")]
        public IActionResult TakeShift(int shiftId)
        {
            string userType = User.Claims.FirstOrDefault(c => c.Type == "UserType")?.Value;

            if (userType == "Client")
            {
                // cliente toma un turno
                var result = _shiftService.AssignShiftToClient(shiftId, userId); 

            }
            else
            {
  
                return Forbid();
            }
        }

    }
}
