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
        public readonly ILogger<CourseController> _logger;

        public CourseController(ILogger<CourseController> logger, ICourseService coursesService)
        {
            _logger = logger;
            _coursesService = coursesService;
        }

        [HttpPost("course")]
        public async Task<IActionResult> GetCoursesWithParameters([FromBody] CourseParameter request)
        {
            var courses = await _coursesService.GetCoursesAsync(request);
            return Ok(courses);
        }
        /*

        [HttpGet(Name = nameof(CoursesAsync))]
        public async Task<IActionResult> CoursesAsync()
        {
            var courses = await _coursesService.GetCoursesAsync();
            return Ok(courses);
        }
        */
    }
}
