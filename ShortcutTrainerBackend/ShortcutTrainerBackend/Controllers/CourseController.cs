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

    }
}
