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

                // return (!user.Id.Equals(default(Guid).ToString())) ?
                //        Ok(user) :
                //        NotFound("Es wurde kein Benutzer mit der ID gefunden.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen des Benutzers: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpPost(Name = nameof(AddUser))]
        public async Task<IActionResult> AddUser([FromQuery] UserParameter request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("User data is invalid.");
                }

                var addedUser = await _userService.AddUserAsync(request);
                var defaultGuid = default(Guid).ToString().Replace("{", "").Replace("}", "");

                return (!addedUser.Id.Equals(defaultGuid)) ?
                       Ok(request) :
                       Problem("Der Benutzer existiert bereits.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Hinzufügen des Benutzers: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpPost(Name = nameof(UpdateUser))]
        public async Task<IActionResult> UpdateUser([FromQuery] UserParameter request)
        {
           try
           {
               if (request == null)
               {
                   return BadRequest("User data is invalid.");
               }

                var updateUser = await _userService.UpdateUserAsync(request);
                var defaultGuid = default(Guid).ToString().Replace("{", "").Replace("}", "");

                return (!updateUser.Id.Equals(defaultGuid)) ?
                       Ok(request) :
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
