using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class CourseService : ICourseService
    {
        public async Task<IEnumerable<Course>> GetCoursesAsync(CourseParameter request)
        {
            return await Task.FromResult(Enumerable.Empty<Course>());
        }
    }
}
