using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockQuestionDatabase : IMockDatabase<Question>
    {
        public List<Question> DataStore { get; } = new List<Question>
        {
            new()
            {
                Id = 1,
                Content = "Wie lautet die Tastenkombination zum Kopieren?",
                Shortcut = "Strg+C",
                Result = QuestionStatus.Unanswered,
                QuestionParameter = new List<QuestionParameter>
                {
                    new()
                    {
                        CourseID = 1,
                        Language = "de_de",
                        OperatingSystem = "Linux",
                        KeyboadLayout = "QWERTZ"
                    }
                }
            },
            new()
            {
                Id = 2,
                Content = "Wie speichert man ein Dokument mit einer Tastenkombination?",
                Shortcut = "Strg+S",
                Result = QuestionStatus.Correct,
                QuestionParameter = new List<QuestionParameter>
                {
                    new()
                    {
                        CourseID = 2,
                        Language = "de_de",
                        OperatingSystem = "Linux",
                        KeyboadLayout = "QWERTZ"
                    }
                }
            },
            new()
            {
                Id = 3,
                Content = "Tastenkombination zum Einfügen?",
                Shortcut = "Strg+V",
                Result = QuestionStatus.Incorrect,
                QuestionParameter = new List<QuestionParameter>
                {
                    new()
                    {
                        CourseID = 3,
                        Language = "de_de",
                        OperatingSystem = "Linux",
                        KeyboadLayout = "QWERTZ"
                    }
                }
            },
            new()
            {
                Id = 4,
                Content = "Was ist die Tastenkombination, um rückgängig zu machen?",
                Shortcut = "Strg+Z",
                Result = QuestionStatus.Correct,
                QuestionParameter = new List<QuestionParameter>
                {
                    new()
                    {
                        CourseID = 1,
                        Language = "de_de",
                        OperatingSystem = "Linux",
                        KeyboadLayout = "QWERTZ"
                    }
                }
            },
            new()
            {
                Id = 5,
                Content = "Wie öffnet man die Entwicklertools im Browser?",
                Shortcut = "Strg+Shift+I",
                Result = QuestionStatus.Incorrect,
                QuestionParameter = new List<QuestionParameter>
                {
                    new()
                    {
                        CourseID = 2,
                        Language = "de_de",
                        OperatingSystem = "Linux",
                        KeyboadLayout = "QWERTZ"
                    }
                }
            },
            new()
            {
                Id = 6,
                Content = "Tastenkombination zum Neuladen einer Seite im Browser?",
                Shortcut = "Strg+R",
                Result = QuestionStatus.Unanswered,
                QuestionParameter = new List<QuestionParameter>
                {
                    new()
                    {
                        CourseID = 3,
                        Language = "de_de",
                        OperatingSystem = "Linux",
                        KeyboadLayout = "QWERTZ"
                    }
                }
            }
        };

        public async Task<IEnumerable<Question>> GetDataAsync()
        {
            return await Task.FromResult(DataStore.AsEnumerable());
        }

        public async Task SetDataAsync(IEnumerable<Question> data)
        {
            await Task.Delay(2000); // wait 2 seconds before returning any result
            DataStore.AddRange(data);
            await Task.CompletedTask;
        }
    }
}