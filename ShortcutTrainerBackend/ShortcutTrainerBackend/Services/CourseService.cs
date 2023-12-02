using DevExpress.Xpo;
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
            var courses = await _mockDatabase.GetDataAsync();

            var filteredCourses = courses.Select(c => new Course
            {
                Id = c.Id,
                Title = c.Title,
                Language = c.Language,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                Subscription = c.Subscription,
                Tags = new XPCollection<CourseTag>(c.Tags),
                UserCourses = new XPCollection<UserCourse>(c.UserCourses)
            });


            //if (!string.IsNullOrEmpty(request.Category))
            //{
            //    filteredCourses = filteredCourses.Where(c => c.Category.Name == request.Category);
            //}

            //if (!string.IsNullOrEmpty(request.SearchString))
            //{
            //    filteredCourses = filteredCourses.Where(c =>
            //        c.Title.Contains(request.SearchString, StringComparison.OrdinalIgnoreCase) ||
            //        c.Description.Contains(request.SearchString, StringComparison.OrdinalIgnoreCase)
            //    );
            //}

            //if (request.Limit.HasValue)
            //{
            //    filteredCourses = filteredCourses.Take(request.Limit.Value);
            //}


            //if (request.UserID == 0)
            //{
            //    //Default-Implementation for UserId == 0

            //    return filteredCourses;
            //}

            //if (request.UserID == null)
            //{
            //    filteredCourses = filteredCourses.Where(c => c.PaymentType == "Kostenlos");
            //}

            return filteredCourses;

        }
    }
}
