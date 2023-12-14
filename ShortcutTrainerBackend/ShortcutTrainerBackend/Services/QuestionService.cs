using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class QuestionService : IQuestionService
    {
        public async Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParameter request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetUnansweredQuestionsAsync(QuestionParameter request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetIncorrectQuestionsAsync(QuestionParameter request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetCorrectQuestionsAsync(QuestionParameter request)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateQuestionStatusAsync(int questionId, string questionStatus)
        {
            throw new NotImplementedException();
        }
    }
}
