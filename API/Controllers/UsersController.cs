using API.Data.Models;
using API.DTOs;
using API.ServiceContracts;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var userDto = await _usersService.GetUserAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO userDto)
        {
            if (id != userDto.ID)
            {
                return BadRequest();
            }

            var updatedUserDto = await _usersService.UpdateUserAsync(userDto);
            if (updatedUserDto == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
