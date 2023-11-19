using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Data;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services;

public class QuestionService : IQuestionService
{

    public QuestionService(IMockDatabase<Question> database)
    {
        _database = database;
    }

    //private readonly MockQuestionDatabase _database;
    private readonly IMockDatabase<Question> _database;


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