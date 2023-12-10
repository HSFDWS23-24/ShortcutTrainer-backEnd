using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponse>> GetCoursesAsync(CourseParameter request);
    }
}
