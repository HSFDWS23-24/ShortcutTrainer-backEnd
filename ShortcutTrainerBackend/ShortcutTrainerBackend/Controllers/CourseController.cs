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

        [HttpGet("courses")]
        public async Task<IActionResult> CoursesAsync([FromQuery] CourseParameter request)
        {
            return Ok(await _coursesService.GetCoursesAsync(request));
        }

    }
}
