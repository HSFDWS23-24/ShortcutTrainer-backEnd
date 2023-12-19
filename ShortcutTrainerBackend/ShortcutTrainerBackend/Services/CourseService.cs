using DevExpress.Xpo;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class CourseService : ICourseService
    {
        public CourseService(Session session, IQuestionService questionService)
        {
            _session = session;
            _questionService = questionService;
        }

        private readonly Session _session;
        private readonly IQuestionService _questionService;
        
        
        private async Task<IEnumerable<DtoCourse>> GetFreeCoursesAsync(string language, string? system, int? limit = null)
        {
            var courses = new XPCollection<Course>(_session)
                .Where(c => c.Subscription == "free" && c.Language == language)
                .Take(limit ?? 100)
                .Select(c => new DtoCourse
                {
                    Id = c.Id,
                    Title = c.Title,
                    Language = c.Language,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Subscription = c.Subscription,
                    Tags = c.Tags.Select(ct => new DtoCourseTag { Tag = ct.Key.Tag }),
                    Questions = system == null ? null : _questionService.GetQuestions(c.Id, language, system)
                });
            return await Task.FromResult(courses);
        }
        
        // ToDo: bitte in API-Doku übernehmen (aber in bschöner): Freie Kurse werden zurückgegeben, sofern keine UserId angegeben wird | Wird ein System angegeben, werden Fragen mit geladen
        public async Task<IEnumerable<DtoCourse>> GetCoursesAsync(string? userId, string language, string? system, string? searchString, int? limit)
        {
            var courses = userId == null
                ? await GetFreeCoursesAsync(language, system, limit)
                : new XPCollection<UserCourse>(_session)
                    .Where(uc => uc.Key.User.Id == userId)
                    .Take(limit ?? 100)
                    .Select(uc => new DtoCourse
                    {
                        Id = uc.Key.Course.Id,
                        Title = uc.Key.Course.Title,
                        Language = uc.Key.Course.Language,
                        Description = uc.Key.Course.Description,
                        ImageUrl = uc.Key.Course.ImageUrl,
                        Subscription = uc.Key.Course.Subscription,
                        IsFavorite = uc.Favorite,
                        Tags = uc.Key.Course.Tags.Select(ct => new DtoCourseTag { Tag = ct.Key.Tag }),
                        Questions = system == null ? null : _questionService.GetQuestions(uc.Key.Course.Id, language, system)
                    });
            return await Task.FromResult(courses);
        }
    }
}










//using ShortcutTrainerBackend.Data.Models;
//using ShortcutTrainerBackend.Services.Interfaces;
//using ShortcutTrainerBackend.Testing.Mocks.Interfaces;
//using System.Collections.Generic;

//namespace ShortcutTrainerBackend.Services
//{
//    public class CourseService : ICourseService
//    {
//        private readonly IMockDatabase<Course> _mockDatabase;
//        private readonly IMockDatabase<UserAnswer> _mockUserAnwserDatabase;
//        public CourseService(IMockDatabase<Course> mockDatabase, IMockDatabase<UserAnswer> mockUserAnwserDatabase)
//        {
//            _mockDatabase = mockDatabase;
//            _mockUserAnwserDatabase = mockUserAnwserDatabase;
//        }

//        public async Task<IEnumerable<CourseResponse>> GetCoursesAsync(CourseParameter request)
//        {
//            var userID = request.UserID;
//            var language = request.Language ?? "de";
//            var searchString = request.SearchString ?? "";
//            var subscription = request.SubscriptionType ?? SubscriptionType.Free;
//            var tag = request.Tag;

//            var limit = request.Limit ?? 1000;
//            var courses = await _mockDatabase.GetDataAsync();
//            if (userID == null || userID == "0") //Session specific logic later
//            {
//                var freeCourses = courses
//                    .Where(c => c.Subscription == SubscriptionType.Free)
//                    .Select(c => MapToCourseResponse(c));

//                return freeCourses.Take(limit);

//            }

//            // Courses from User
//            var userCourses = courses
//                .Where(c => c.UserCourses.Any(u => u.User.Id == userID))
//                .Select(c => MapToCourseResponseWithUser(c, userID));

//            // Filter Courses
//            var filteredCourses = userCourses
//               .Where(c => c.Language == language &&
//                           (c.Title.ToLower().Contains(searchString.ToLower()) ||
//                            c.Description.ToLower().Contains(searchString.ToLower())) &&
//                           c.Subscription == subscription);


//            if (tag != null)
//            {
//                filteredCourses = filteredCourses.Where(c => c.Tags.Any(t => t.Tag.ToLower() == tag.ToLower()));
//            }

//            return filteredCourses.Take(limit);
//        }
//        private CourseResponse MapToCourseResponse(Course course)
//        {
//            var questions = _mockUserAnwserDatabase.GetDataAsync().Result
//            .Where(ua => ua.Answer.Question.Course.Id == course.Id)
//            .Select(ua => ua.Answer.Question).DistinctBy(q => q.Id);

//            var amountQuestions = questions.Count();

//            return new CourseResponse
//            {
//                Id = course.Id,
//                Title = course.Title,
//                Language = course.Language,
//                Description = course.Description,
//                ImageUrl = course.ImageUrl,
//                Subscription = course.Subscription,
//                Tags = course.Tags,
//                IsFavorite = null, // Set default value for free courses(no User)
//                AnsweredCorrect = null,
//                AnsweredIncorrect = null,
//                AmountQuestions = amountQuestions
//            };
//        }

//        private CourseResponse MapToCourseResponseWithUser(Course course, string userID)
//        {
//            var questions = _mockUserAnwserDatabase.GetDataAsync().Result
//            .Where(ua => ua.Answer.Question.Course.Id == course.Id)
//            .Select(ua => ua.Answer.Question).DistinctBy(q => q.Id);

//            var amountQuestions = questions.Count();

//            var userCorrectAnswers = _mockUserAnwserDatabase.GetDataAsync().Result
//            .Where(ua => ua.User.Id == userID && ua.Answer.Question.Course.Id == course.Id 
//            && ua.QuestionStatus == QuestionStatusType.Correct)
//            .Select(ua => ua.Answer.Question)
//            .DistinctBy(q => q.Id);

//            var answeredCorrect = userCorrectAnswers.Count();

//            var userIncorrectAnswers = _mockUserAnwserDatabase.GetDataAsync().Result
//            .Where(ua => ua.User.Id == userID && ua.Answer.Question.Course.Id == course.Id
//            && ua.QuestionStatus == QuestionStatusType.Incorrect)
//            .Select(ua => ua.Answer.Question)
//            .DistinctBy(q => q.Id);

//            var answeredIncorrect = userIncorrectAnswers.Count();

//            return new CourseResponse
//            {
//                Id = course.Id,
//                Title = course.Title,
//                Language = course.Language,
//                Description = course.Description,
//                ImageUrl = course.ImageUrl,
//                Subscription = course.Subscription,
//                Tags = course.Tags,
//                IsFavorite = course.UserCourses.FirstOrDefault(uc => uc.User.Id == userID)?.Favorite ?? false,
//                AnsweredCorrect = answeredCorrect, 
//                AnsweredIncorrect = answeredIncorrect,
//                AmountQuestions = amountQuestions
//            };
//        }
//    }
//}
