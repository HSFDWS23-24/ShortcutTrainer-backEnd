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
