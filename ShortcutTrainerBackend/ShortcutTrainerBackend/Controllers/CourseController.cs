using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
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
        public async Task<IActionResult> GetCourses([FromQuery] CourseParameter request)
        {
            var courses = await _coursesService.GetCoursesAsync(request);
            return Ok(courses);
        }

    }
}
