using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsersAsync();
            return (users.Any()) ?
                Ok(users) :
                NotFound("Es wurden keine Benutzer gefunden.");
        }

        [HttpGet(Name = nameof(GetUser))]
        public async Task<IActionResult> GetUser([FromQuery] UserParameter request)
        {
            try
            {
                var user = await _userService.GetUserAsync(request);

                return (!user.Id.Equals(default(Guid).ToString())) ?
                       Ok(user) :
                       NotFound("Es wurde kein Benutzer mit der ID gefunden.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen des Benutzers: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpPost(Name = nameof(AddUser))]
        public async Task<IActionResult> AddUser([FromQuery] User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("User data is invalid.");
                }

                var addedUser = await _userService.AddUserAsync(user);

                return (!addedUser.Id.Equals(default(Guid).ToString())) ?
                       Ok(user) :
                       Problem("Der Benutzer existiert bereits.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Hinzufügen des Benutzers: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpPost(Name = nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser([FromQuery] User user)
        {
           try
           {
               if (user == null)
               {
                   return BadRequest("User data is invalid.");
               }

                var updateUser = await _userService.UpdateUserAsync(user);

                return (!updateUser.Id.Equals(default(Guid).ToString())) ?
                       Ok(user) :
                       Problem("Der Benutzer existiert nicht.");
           }
           catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Updaten des Benutzers: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }
    }
}
