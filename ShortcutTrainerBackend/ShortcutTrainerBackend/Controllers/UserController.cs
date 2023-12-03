using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;

        }

        [HttpGet(Name = nameof(GetUsers))]
        public async Task<IActionResult> GetUsers([FromQuery] UserParameter request)
        {
            var users = await _userService.GetUsersAsync(request);
            return Ok(users);
        }

        [HttpPost(Name = nameof(AddUser))]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is invalid.");
                }

                var addedUser = await _userService.AddUserAsync(user);

                return CreatedAtAction(nameof(AddUser), new { id = addedUser.Id }, addedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding user: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost(Name = nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is invalid.");
                }

                var updatedUser = await _userService.UpdateUserAsync(user);

                return CreatedAtAction(nameof(UpdateUser), new { id = updatedUser.Id }, updatedUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding user: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
