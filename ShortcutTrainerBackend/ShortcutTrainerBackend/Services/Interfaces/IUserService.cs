using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<Question>> GetUnansweredQuestionsAsync(int courseId, string language, string keyboardLayout);
        Task<IEnumerable<Question>> GetIncorrectQuestionsAsync(int courseId, string language, string keyboardLayout);
        Task<IEnumerable<Question>> GetCorrectQuestionsAsync(int courseId, string language, string keyboardLayout);
        Task UpdateAnswerStatusAsync(int questionId, QuestionResult result);
    }
}
