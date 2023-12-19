using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserCourseController : Controller
    {
        private readonly IUserCourseService _userCourseService;
        private readonly ILogger<UserCourseController> _logger;

        public UserCourseController(ILogger<UserCourseController> logger, IUserCourseService userCourseService)
        {
            _logger = logger;
            _userCourseService = userCourseService;

        }

        [HttpGet(Name = nameof(GetUserCourses))]
        public async Task<IActionResult> GetUserCourses([FromQuery] UserCourseParameter request)
        {
            try
            {
                var userCourses = await _userCourseService.GetUserCoursesAsync(request);

                return (userCourses.Any()) ?
                       Ok(userCourses) :
                       NotFound("Es wurden keine Kurse für den Benutzer gefunden.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen der Kurse des Benutzers: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpGet(Name = nameof(GetUserCourse))]
        public async Task<IActionResult> GetUserCourse([FromQuery] UserCourseParameter request)
        {
            try
            {
                var userCourse = await _userCourseService.GetUserCourseAsync(request);

                return (!userCourse.User.Id.Equals(default(Guid).ToString())) ?
                       Ok(userCourse) :
                       NotFound("Der Kurs wurde für den Benutzer nicht gefunden");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen des Kurses des Benutzers: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpPost(Name = nameof(AddUserCourse))]
        public async Task<IActionResult> AddUserCourse([FromQuery] UserCourseParameter request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Parameter are invalid.");
                }

                var addedUserCourse = await _userCourseService.AddUserCourseAsync(request);

                return (!addedUserCourse.User.Id.Equals(default(Guid).ToString())) ?
                       Ok(addedUserCourse) :
                       Problem("Der Kurs existiert für den Benutzer bereits.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Hinzufügen des Kurses für den Benutzer: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }

        [HttpPost(Name = nameof(UpdateUserCourse))]
        public async Task<IActionResult> UpdateUserCourse([FromQuery] UserCourseParameter request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Parameter are invalid.");
                }

                var updatedUserCourse = await _userCourseService.UpdateUserCourseAsync(request);

                return (!updatedUserCourse.User.Id.Equals(default(Guid).ToString())) ?
                       Ok(updatedUserCourse) :
                       Problem("Der Kurs konnte für den Benutzer nicht geupdated werden.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Updaten des Kurses für den Benutzer: {ex.Message}");
                return StatusCode(500, "Ein interner Fehler ist aufgetreten.");
            }
        }
    }
}
