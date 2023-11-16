using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
  public interface ICourseDetailService
  {
    Task<IEnumerable<Course>> GetCourseDetailAsync(CourseParameter request);
  }
}