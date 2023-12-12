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
                x.UserId.Equals(request.UserID));

            if (userCourseList != null)
            {
                foreach(var userCourse in userCourseList)
                {
                    var course = _mockDatabaseCourse.DataStore.FirstOrDefault(x => x.Id.Equals(userCourse.CourseId));
                    
                    if (course != null)
                    {
                        userCourse.Course = course;
                    }
                }

                return await Task.FromResult(userCourseList);
            }
            return await Task.FromResult(Enumerable.Empty<UserCourse>());
        }

        public async Task<UserCourse> GetUserCourseAsync(UserCourseParameter request)
        {
            var userCourse = _mockDatabaseUserCourse.DataStore.FirstOrDefault(x =>
                x.UserId.Equals(request.UserID) &&
                x.CourseId.Equals(request.CourseID));

            if (userCourse != null)
            {
                var course = _mockDatabaseCourse.DataStore.FirstOrDefault(x => x.Id.Equals(request.CourseID));

                if (course != null)
                {
                    userCourse.Course = course;
                }

                return await Task.FromResult(userCourse);
            }
            return await Task.FromResult(new UserCourse());
        }

        public async Task<UserCourse> AddUserCourseAsync(UserCourseParameter request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var userCourse = _mockDatabaseUserCourse.DataStore.FirstOrDefault(x =>
                x.UserId.Equals(request.UserID) &&
                x.CourseId.Equals(request.CourseID));

            if (userCourse != null)
            {
                throw new InvalidOperationException("UserCourse with the same IDs already exists");
            }

                var newUserCourse = new UserCourse()
            {
                UserId = request.UserID,
                CourseId = request.CourseID,
                Favorite = request.Favorite
            };

            var course = _mockDatabaseCourse.DataStore.FirstOrDefault(x => x.Id.Equals(request.CourseID));

            if (course != null)
            {
                newUserCourse.Course = course;
            }

            // Add the new user to the database
            _mockDatabaseUserCourse.DataStore.Add(newUserCourse);

            // Simulate asynchronous operation with Task.Delay
            await Task.Delay(1);

            return newUserCourse;
        }
    }
}
