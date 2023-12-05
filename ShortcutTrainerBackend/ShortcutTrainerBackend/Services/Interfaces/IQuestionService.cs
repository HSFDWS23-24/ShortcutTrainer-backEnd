using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParameter request);
        Task<IEnumerable<Question>> GetUnansweredQuestions(int courseId, string language, string OperatingSystem);
        Task<IEnumerable<Question>> GetIncorrectQuestions(int courseId, string language, string OperatingSystem);
        Task<IEnumerable<Question>> GetCorrectQuestions(int courseId, string language, string OperatingSystem);
        Task UpdateQuestionStatus(int questionId, QuestionStatus result);
    }
}
