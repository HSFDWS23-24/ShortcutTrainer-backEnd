using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParameter request);
        Task<IEnumerable<Question>> GetUnansweredQuestionsAsync(QuestionParameter request);
        Task<IEnumerable<Question>> GetIncorrectQuestionsAsync(QuestionParameter request);
        Task<IEnumerable<Question>> GetCorrectQuestionsAsync(QuestionParameter request);
        Task UpdateQuestionStatusAsync(int questionId, string questionStatus);
    }
}
