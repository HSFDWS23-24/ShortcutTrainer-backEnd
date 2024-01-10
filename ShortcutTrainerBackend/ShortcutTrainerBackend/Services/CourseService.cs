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

        private static bool CourseMatchesSearchItems(Course course, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return true;

            var searchItems = searchString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var searchItem in searchItems)
            {
                if (course.Title.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                    course.Description.Contains(searchItem, StringComparison.OrdinalIgnoreCase) ||
                    course.Subscription.Equals(searchItem, StringComparison.OrdinalIgnoreCase) ||
                    course.Tags.Any(ct => ct.Key.Tag.Contains(searchItem, StringComparison.OrdinalIgnoreCase)) ||
                    course.Language.Equals(searchItem, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private async Task<IEnumerable<DtoCourse>> GetFreeCoursesAsync(string language, string? tag, string? searchString, int? limit = null)
        {
            var courses = new XPCollection<Course>(_session)
                .Where(c => c.Subscription == "free" && c.Language == language && CourseMatchesSearchItems(c, searchString))
                .Take(limit ?? 100)
                .Select(c => new DtoCourse
                {
                    Id = c.Id,
                    Title = c.Title,
                    Language = c.Language,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Subscription = c.Subscription,
                    Tags = c.Tags.Where(ct => tag == null || ct.Key.Tag == tag).Select(ct => new DtoCourseTag { Tag = ct.Key.Tag }),
                    AmountQuestions = c.Questions.Count
                });

            return await Task.FromResult(courses);
        }

        public async Task<IEnumerable<DtoCourse>> GetCoursesAsync(string? userId, string language, string? tag, string? searchString, int? limit)
        {
            var courses = userId == null
                ? await GetFreeCoursesAsync(language, tag, searchString, limit)
                : new XPCollection<UserCourse>(_session)
                    .Where(uc => uc.Key.User.Id == userId && uc.Key.Course.Language == language && CourseMatchesSearchItems(uc.Key.Course, searchString))
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
                        Tags = uc.Key.Course.Tags.Where(ct => tag == null || ct.Key.Tag == tag).Select(ct => new DtoCourseTag { Tag = ct.Key.Tag }),
                        AnsweredCorrect = _session.Query<UserAnswer>().Where(ua => ua.Key.User.Id == userId && ua.Key.Answer.Question.Course.Id == uc.Key.Course.Id && ua.QuestionStatus == "correct").Count(),
                        AnsweredIncorrect = _session.Query<UserAnswer>().Where(ua => ua.Key.User.Id == userId && ua.Key.Answer.Question.Course.Id == uc.Key.Course.Id && ua.QuestionStatus == "incorrect").Count(), 
                        AmountQuestions = uc.Key.Course.Questions.Count, 
                    });

            return await Task.FromResult(courses);
        }
    }
}