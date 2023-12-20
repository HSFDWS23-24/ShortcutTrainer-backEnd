using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IQuestionService
    {
        // GetQuestions
        IEnumerable<DtoQuestion> GetQuestions(int courseId, string language, string system);
        Task<IEnumerable<DtoQuestion>> GetQuestionsAsync(int courseId, string language, string system);

        // GetUnansweredQuestions
        IEnumerable<DtoQuestion> GetUnansweredQuestions(int courseId, string language, string system, string userId);
        Task<IEnumerable<DtoQuestion>> GetUnansweredQuestionsAsync(int courseId, string language, string system, string userId);

        // GetIncorrectQuestions
        IEnumerable<DtoQuestion> GetIncorrectQuestions(int courseId, string language, string system, string userId);
        Task<IEnumerable<DtoQuestion>> GetIncorrectQuestionsAsync(int courseId, string language, string system, string userId);

        // GetCorrectQuestions
        IEnumerable<DtoQuestion> GetCorrectQuestions(int courseId, string language, string system, string userId);
        Task<IEnumerable<DtoQuestion>> GetCorrectQuestionsAsync(int courseId, string language, string system, string userId);

        // UpdateQuestionStatusAsync
        Task UpdateQuestionStatusAsync(int questionId, string userId, string questionStatus);
    }
}
