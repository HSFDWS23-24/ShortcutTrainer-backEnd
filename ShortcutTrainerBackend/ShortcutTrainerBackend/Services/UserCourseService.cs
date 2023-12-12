using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IMockDatabase<UserCourse> _mockDatabaseUserCourse;
        private readonly IMockDatabase<Course> _mockDatabaseCourse;
        public UserCourseService(IMockDatabase<UserCourse> mockDatabaseUserCourse,
            IMockDatabase<Course> mockDatabaseCourse)
        {
            _mockDatabaseUserCourse = mockDatabaseUserCourse;
            _mockDatabaseCourse = mockDatabaseCourse;
        }

        public async Task<IEnumerable<UserCourse>> GetUserCoursesAsync(UserCourseParameter request)
        {
            var userCourseList = _mockDatabaseUserCourse.DataStore.Where(x => 
                x.User.Id.Equals(request.UserID));

            if (userCourseList != null)
            {
                return await Task.FromResult(userCourseList);
            }
            return await Task.FromResult(Enumerable.Empty<UserCourse>());
        }

        public async Task<UserCourse> GetUserCourseAsync(UserCourseParameter request)
        {
            var userCourse = _mockDatabaseUserCourse.DataStore.FirstOrDefault(x =>
                x.User.Id.Equals(request.UserID) &&
                x.Course.Id.Equals(request.CourseID));

            if (userCourse != null)
            {
                return await Task.FromResult(userCourse);
            }
            return await Task.FromResult(new UserCourse());
        }

        public async Task<UserCourse> AddUserCourseAsync(UserCourse newUserCourse)
        {
            if (newUserCourse == null)
            {
                throw new ArgumentNullException(nameof(newUserCourse));
            }

            // Add the new user to the database
            _mockDatabaseUserCourse.DataStore.Add(newUserCourse);

            // Simulate asynchronous operation with Task.Delay
            await Task.Delay(1);

            return newUserCourse;
        }
    }
}
