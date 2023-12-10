using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockQuestionDatabase : IMockDatabase<Question>
    {
        public List<Question> DataStore { get; } = new List<Question>
        {
            new Question()
            {
                Id = 1,
                Content = "Wie lautet die Tastenkombination zum Kopieren?",
                Shortcut = "Strg+C",
                Status = QuestionStatus.Unanswered
            },
            new Question()
            {
                Id = 2,
                Content = "Wie speichert man ein Dokument mit einer Tastenkombination?",
                Shortcut = "Strg+S",
                Status = QuestionStatus.Correct
            },
            new Question()
            {
                Id = 3,
                Content = "Tastenkombination zum Einfügen?",
                Shortcut = "Strg+V",
                Status = QuestionStatus.Incorrect
            },
            new Question()
            {
                Id = 4,
                Content = "Was ist die Tastenkombination, um rückgängig zu machen?",
                Shortcut = "Strg+Z",
                Status = QuestionStatus.Correct
            },
            new Question()
            {
                Id = 5,
                Content = "Wie öffnet man die Entwicklertools im Browser?",
                Shortcut = "Strg+Shift+I",
                Status = QuestionStatus.Incorrect
            },
            new Question()
            {
                Id = 6,
                Content = "Tastenkombination zum Neuladen einer Seite im Browser?",
                Shortcut = "Strg+R",
                Status = QuestionStatus.Unanswered
            }
        };

        public async Task<IEnumerable<Question>> GetDataAsync()
        {
            return await Task.FromResult(DataStore.AsEnumerable());
        }

        public async Task SetDataAsync(IEnumerable<Question> data)
        {
            await Task.Delay(2000); // wait 2 seconds before returning any Status
            DataStore.AddRange(data);
            await Task.CompletedTask;
        }
    }
}