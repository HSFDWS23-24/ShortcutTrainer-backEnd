using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces;

public interface IQuestionService
{
    Task<List<Question>> GetAllQuestionsAsync();
    Task<Question> GetQuestionByIdAsync(int id);
}