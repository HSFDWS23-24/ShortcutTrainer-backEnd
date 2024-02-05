using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IUserCourseService
    {
        Task<IEnumerable<DtoUserCourse>> GetUserCoursesAsync(UserCourseParameter request);
        Task<DtoUserCourse> GetUserCourseAsync(UserCourseParameter request);
        Task<DtoUserCourse> AddUserCourseAsync(UserCourseParameter request);
        Task<DtoUserCourse> UpdateUserCourseAsync(UserCourseParameter request);
    }
}
