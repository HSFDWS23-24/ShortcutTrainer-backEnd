using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Data;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services;

public class QuestionService : IQuestionService
{
    private readonly MockQuestionDatabase _database;


    public QuestionService(MockQuestionDatabase database)
    {
        _database = database;
    }

    public async Task<List<Question>> GetAllQuestionsAsync()
    {
        var questions = await _database.GetDataAsync();
        return questions.ToList();
    }

    public async Task<Question> GetQuestionByIdAsync(int id)
    {
        var questions = await _database.GetDataAsync();
        return questions.FirstOrDefault(q => q.Id == id);
    }

}