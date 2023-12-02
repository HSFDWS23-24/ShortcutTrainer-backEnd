using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParameter request);
    }
}
