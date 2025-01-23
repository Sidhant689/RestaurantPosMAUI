using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantPosMAUI.Application.DTOs;
using RestaurantPosMAUI.Application.Interfaces;

namespace RestaurantPosMAUI.API.Controllers
{
    [Log]
    public class APIUserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<APIUserController> _logger;

        public APIUserController(IUserService userService, ILogger<APIUserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet]
        [Route("api/GetUserByIdAsync")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
