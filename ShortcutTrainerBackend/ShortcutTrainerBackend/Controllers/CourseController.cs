using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _coursesService;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ICourseService coursesService)
        {
            _logger = logger;
            _coursesService = coursesService;

        }

        [HttpGet(Name = nameof(GetCourses))]
        public async Task<IActionResult> GetCourses(string? userId, string language, string? tag, string? searchString, int? limit)
        {
            return Ok(await _coursesService.GetCoursesAsync(userId, language, tag, searchString, limit));
        }

        [HttpPost("updateFavourite")]
        public async Task<IActionResult> UpdateFavouriteStatus(int courseId, string userId, bool favouriteStatus)
        {
            if (courseId <= 0)
            {
                return BadRequest("Invalid request data");
            }

            var updateResult = await _coursesService.UpdateFavouriteStatusAsync(courseId, userId, favouriteStatus);
            if (updateResult)
            {
                return Ok(new { Message = "Favourite Attribut erfolgreich aktualisiert", UpdatedFavouriteStatus = favouriteStatus });
            }
            else
            {
                return BadRequest("Fehler beim Aktualisieren des Favourite Attributs");
            }
        }

    }
}
