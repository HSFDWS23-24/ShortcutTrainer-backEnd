using DevExpress.Xpo;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class QuestionService : IQuestionService
    {
        public QuestionService(Session session)
        {
            _session = session;
        }

        private readonly Session _session;

        public IEnumerable<DtoQuestion> GetQuestions(int courseId, string language, string system)
        {
            var questions = new XPCollection<Question>(_session)
                .Where(q => q.Course.Id == courseId && q.Course.Language == language)
                .Select(q => new DtoQuestion
                {
                    Id = q.Id,
                    Content = q.Content,
                    Answers = q.Answers
                        .Where(a => a.System == system)
                        .Select(a => new DtoAnswer
                        {
                            Id = a.Id,
                            System = a.System,
                            Shortcut = a.Shortcut
                        })
                });
            return questions;
        }
        
        public async Task<IEnumerable<DtoQuestion>> GetQuestionsAsync(int courseId, string language, string system)
        {
            return await Task.FromResult(GetQuestions(courseId, language, system));
        }

        public async Task<IEnumerable<DtoQuestion>> GetUnansweredQuestionsAsync(QuestionParameter request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DtoQuestion>> GetIncorrectQuestionsAsync(QuestionParameter request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DtoQuestion>> GetCorrectQuestionsAsync(QuestionParameter request)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateQuestionStatusAsync(int questionId, string questionStatus)
        {
            throw new NotImplementedException();
        }
    }
}
