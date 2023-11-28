using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockQuestionDatabase : IMockDatabase<Question>
    {
        public List<Question> DataStore { get; } = new List<Question>
        {
            /*new()
            {
                Id = 1,
                Content = "Wie lautet die Tastenkombination zum Kopieren?",
                Shortcut = "Strg+C"
            },
            new()
            {
                Id = 2,
                Content = "Wie speichert man ein Dokument mit einer Tastenkombination?",
                Shortcut = "Strg+S"
            },
            new()
            {
                Id = 3,
                Content = "Tastenkombination zum Einfügen?",
                Shortcut = "Strg+V"
            },
            new()
            {
                Id = 4,
                Content = "Was ist die Tastenkombination, um rückgängig zu machen?",
                Shortcut = "Strg+Z"
            },
            new()
            {
                Id = 5,
                Content = "Wie öffnet man die Entwicklertools im Browser?",
                Shortcut = "Strg+Shift+I"
            },
            new()
            {
                Id = 6,
                Content = "Tastenkombination zum Neuladen einer Seite im Browser?",
                Shortcut = "Strg+R"
            }*/
            new()
            {
                Id = 1,
                Content = "Wie lautet die Tastenkombination zum Kopieren?",
                Shortcut = "Strg+C",
                QuestionsParameter = new List<QuestionParameter>
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
                QuestionsParameter = new List<QuestionParameter>
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
                Id = 3,
                Content = "Tastenkombination zum Einfügen?",
                Shortcut = "Strg+V",
                QuestionsParameter = new List<QuestionParameter>
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
                Id = 4,
                Content = "Was ist die Tastenkombination, um rückgängig zu machen?",
                Shortcut = "Strg+Z",
                QuestionsParameter = new List<QuestionParameter>
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
                QuestionsParameter = new List<QuestionParameter>
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
                Id = 6,
                Content = "Tastenkombination zum Neuladen einer Seite im Browser?",
                Shortcut = "Strg+R",
                QuestionsParameter = new List<QuestionParameter>
                {
                    new()
                    {
                        CourseID = 1,
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
            DataStore.AddRange(data);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await Task.Delay(100);
        }
    }
}