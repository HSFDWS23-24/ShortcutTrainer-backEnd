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
            var userCourses = await _userCourseService.GetUserCoursesAsync(request);
            return Ok(userCourses);
        }

        [HttpGet(Name = nameof(GetUserCourse))]
        public async Task<IActionResult> GetUserCourse([FromQuery] UserCourseParameter request)
        {
            var userCourse = await _userCourseService.GetUserCourseAsync(request);
            return Ok(userCourse);
        }

        [HttpPost(Name = nameof(AddUserCourse))]
        public async Task<IActionResult> AddUserCourse([FromQuery] UserCourseParameter request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("UserCourse data is invalid.");
                }

                var addedUserCourse = await _userCourseService.AddUserCourseAsync(request);

                return Ok(addedUserCourse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding user: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
