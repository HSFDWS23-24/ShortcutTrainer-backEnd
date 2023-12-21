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


        private async Task<IEnumerable<DtoCourse>> GetFreeCoursesAsync(string language, string? tag, string? searchString, int? limit = null)
        {
            var courses = new XPCollection<Course>(_session)
                .Where(c => c.Subscription == "free" && c.Language == language && (string.IsNullOrEmpty(searchString) || c.Title.Contains(searchString) || c.Description.Contains(searchString)))
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
                    .Where(uc => uc.Key.User.Id == userId && uc.Key.Course.Language == language && (string.IsNullOrEmpty(searchString) || uc.Key.Course.Title.Contains(searchString) || uc.Key.Course.Description.Contains(searchString)))
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
                        AnsweredInCorrect = _session.Query<UserAnswer>().Where(ua => ua.Key.User.Id == userId && ua.Key.Answer.Question.Course.Id == uc.Key.Course.Id && ua.QuestionStatus == "incorrect").Count(), 
                        AmountQuestions = uc.Key.Course.Questions.Count, 
                    });

            return await Task.FromResult(courses);
        }
    }
}











