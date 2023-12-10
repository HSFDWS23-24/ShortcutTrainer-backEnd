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
        private readonly IMockDatabase<UserAnswer> _mockUserAnwserDatabase;
        public CourseService(IMockDatabase<Course> mockDatabase, IMockDatabase<UserAnswer> mockUserAnwserDatabase)
        {
            _mockDatabase = mockDatabase;
            _mockUserAnwserDatabase = mockUserAnwserDatabase;
        }

        public async Task<IEnumerable<CourseResponse>> GetCoursesAsync(CourseParameter request)
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
                var freeCourses = courses
                    .Where(c => c.Subscription == SubscriptionType.Free)
                    .Select(c => MapToCourseResponse(c));

                return freeCourses.Take(limit);

            }

            // Courses from User
            var userCourses = courses
                .Where(c => c.UserCourses.Any(u => u.User.Id == userID))
                .Select(c => MapToCourseResponseWithUser(c, userID));

            // Filter Courses
            var filteredCourses = userCourses
               .Where(c => c.Language == language &&
                           (c.Title.ToLower().Contains(searchString.ToLower()) ||
                            c.Description.ToLower().Contains(searchString.ToLower())) &&
                           c.Subscription == subscription);


            if (tag != null)
            {
                filteredCourses = filteredCourses.Where(c => c.Tags.Any(t => t.Tag.ToLower() == tag.ToLower()));
            }

            return filteredCourses.Take(limit);
        }
        private CourseResponse MapToCourseResponse(Course course)
        {
            var questions = _mockUserAnwserDatabase.GetDataAsync().Result
            .Where(ua => ua.Answer.Question.Course.Id == course.Id)
            .Select(ua => ua.Answer.Question)
            .Distinct();

            var amountQuestions = questions.Count();

            return new CourseResponse
            {
                Id = course.Id,
                Title = course.Title,
                Language = course.Language,
                Description = course.Description,
                ImageUrl = course.ImageUrl,
                Subscription = course.Subscription,
                Tags = course.Tags,
                IsFavorite = null, // Set default value for free courses(no User)
                AnsweredCorrect = null,
                AnsweredIncorrect = null,
                AmountQuestions = amountQuestions
            };
        }

        private CourseResponse MapToCourseResponseWithUser(Course course, string userID)
        {
            return new CourseResponse
            {
                Id = course.Id,
                Title = course.Title,
                Language = course.Language,
                Description = course.Description,
                ImageUrl = course.ImageUrl,
                Subscription = course.Subscription,
                Tags = course.Tags,
                IsFavorite = course.UserCourses.FirstOrDefault(uc => uc.User.Id == userID)?.Favorite ?? false,
                AnsweredCorrect = 0, // You may need to update these values based on actual user data
                AnsweredIncorrect = 0,
                AmountQuestions = 0
            };
        }
    }
}
