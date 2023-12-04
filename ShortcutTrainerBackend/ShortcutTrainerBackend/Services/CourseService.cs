using DevExpress.Xpo;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;
using System.Collections.Generic;

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
            var userID = request.UserID;
            var language = request.Language ?? "de";
            var searchString = request.SearchString ?? "";
            var subscription = request.SubscriptionType ?? SubscriptionType.Free;
            var tag = request.Tag;

            var limit = request.Limit ?? 1000;
            var courses = await _mockDatabase.GetDataAsync();
            if (userID == null || userID == "0") //Session specific logic later
            {
                courses = courses.Select(c => new Course
                {
                    Id = c.Id,
                    Title = c.Title,
                    Language = c.Language,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Subscription = c.Subscription,
                    Tags = c.Tags
                });
                return courses.Where(c => c.Subscription == SubscriptionType.Free);

            }
            courses = courses.Where(c => c.UserCourses.Any(u => u.User.Id == userID));

            courses = courses.Select(c => new Course
            {
                Id = c.Id,
                Title = c.Title,
                Language = c.Language,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                Subscription = c.Subscription,
                Tags = c.Tags,
                UserCourses = c.UserCourses
                .Where(uc => uc.User.Id == userID)
                .Select(uc => new UserCourse
                {
                    User = null,
                    Course = null,
                    Favorite = uc.Favorite
                })
                .ToList()
            }) ;
            courses = courses.Where(c => c.Language == language);
            courses = courses.Where(c =>
            c.Title.ToLower().Contains(searchString.ToLower()) ||
            c.Description.ToLower().Contains(searchString.ToLower()));
            courses = courses.Where(c => c.Subscription == subscription);
            if(tag != null)
            {
                courses = courses.Where(c => c.Tags.Any(t => t.Tag.ToLower() == tag.ToLower()));
            }
            
            

            courses = courses.Take(limit);
            return courses;
        }
    }
}
