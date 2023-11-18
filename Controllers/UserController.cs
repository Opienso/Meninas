using Meninas.Context;
using Meninas.Entities;
using Meninas.Models;
using Meninas.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meninas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost ("client/")]
        public IActionResult CreateClient([FromBody] UserDto userDto) {
            Client client = new Client() {
             Email = userDto.Email, 
             Name = userDto.Name,
             Password = userDto.Password,
             UserType = "client",
            };
            int id = _userService.CreateUser(client);
            return Ok(id);
        }
        //Puede que esto lo hagamos en un solo post. Diferenciando el tipo de entidad, debemos debatirlo.
        [HttpPost("sitter/")]
        public IActionResult CreateSitter([FromBody] UserDto userDto)
        {
            Sitter sitter = new Sitter()
            {
                Email = userDto.Email,
                Name = userDto.Name,
                Password = userDto.Password,
                UserType = "sitter",
            };
            int id = _userService.CreateUser(sitter);
            return Ok(id);
        }


    }
}
