using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IUserCourseService
    {
        Task<IEnumerable<UserCourse>> GetUserCoursesAsync(UserCourseParameter request);
        Task<UserCourse> GetUserCourseAsync(UserCourseParameter request);
        Task<UserCourse> AddUserCourseAsync(UserCourseParameter request);
    }
}
