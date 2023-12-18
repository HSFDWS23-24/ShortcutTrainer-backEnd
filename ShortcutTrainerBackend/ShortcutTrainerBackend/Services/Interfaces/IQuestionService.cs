using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;

namespace ShortcutTrainerBackend.Services.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<DtoQuestion> GetQuestions(int courseId, string language, string system);
        Task<IEnumerable<DtoQuestion>> GetQuestionsAsync(int courseId, string language, string system);
        Task<IEnumerable<DtoQuestion>> GetUnansweredQuestionsAsync(QuestionParameter request);
        Task<IEnumerable<DtoQuestion>> GetIncorrectQuestionsAsync(QuestionParameter request);
        Task<IEnumerable<DtoQuestion>> GetCorrectQuestionsAsync(QuestionParameter request);
        Task UpdateQuestionStatusAsync(int questionId, string questionStatus);
    }
}
