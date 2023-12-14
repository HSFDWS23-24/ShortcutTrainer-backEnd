using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class QuestionService : IQuestionService
    {
        public async Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParameter request)
        {
            return await Task.FromResult(Enumerable.Empty<Question>());
        }
    }
}
