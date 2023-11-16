using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class CourseDetailController : Controller
  {
    private readonly ICourseDetailService _courseDetailService;
    public readonly ILogger<CourseDetailController> _logger;
    
    public CourseDetailController(ILogger<CourseDetailController> logger, ICourseDetailService courseDetailService)
    {
      _logger = logger;
      _courseDetailService = courseDetailService;
    }

    [HttpPost("courseDetail")]

    public async Task<IActionResult> GetCoursesWithParameters([FromBody] CourseParameter request)
    {
      var courseDetail = await _courseDetailService.GetCourseDetailAsync(request);
      return Ok(courseDetail);
    }

  }
}