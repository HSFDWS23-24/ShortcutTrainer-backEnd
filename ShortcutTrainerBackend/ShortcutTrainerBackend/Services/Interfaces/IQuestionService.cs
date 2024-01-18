using ShortcutTrainerBackend.Data.TransferObjects;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IQuestionService
    {

        // GetQuestions
        IEnumerable<DtoQuestion> GetQuestions(string? userId, int courseId, string language, string system);
        Task<IEnumerable<DtoQuestion>> GetQuestionsAsync(string? userId, int courseId, string language, string system);

        // GetUnansweredQuestions
        IEnumerable<DtoQuestion> GetUnansweredQuestions(string? userId, int courseId, string language, string system);
        Task<IEnumerable<DtoQuestion>> GetUnansweredQuestionsAsync(string? userId, int courseId, string language, string system);

        // GetIncorrectQuestions
        IEnumerable<DtoQuestion> GetIncorrectQuestions(string? userId, int courseId, string language, string system);
        Task<IEnumerable<DtoQuestion>> GetIncorrectQuestionsAsync(string? userId, int courseId, string language, string system);

        // GetCorrectQuestions
        IEnumerable<DtoQuestion> GetCorrectQuestions(string? userId, int courseId, string language, string system);
        Task<IEnumerable<DtoQuestion>> GetCorrectQuestionsAsync(string? userId, int courseId, string language, string system);

        // UpdateQuestionStatusAsync
        Task<bool> UpdateQuestionStatusAsync(string? userId, int questionId, string questionStatus);
    }
}
