using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMockDatabase<Course> _mockDatabase;
        public CourseService(IMockDatabase<Course> mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(CourseParameter request)
        {
            // The request contains parameters to filter the desired courses

            return await _mockDatabase.GetDataAsync(); ;

        }
    }
}
