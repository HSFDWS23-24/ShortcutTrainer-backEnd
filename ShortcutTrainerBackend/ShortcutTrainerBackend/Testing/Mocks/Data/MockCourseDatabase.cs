using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockCourseDatabase : IMockDatabase<Course>
    {
        public MockCourseDatabase(IMockDatabase<Question> questionDatabase)
        {
            var questions = questionDatabase.GetDataAsync().Result.ToList();
            DataStore = new List<Course>
            {
                /*new()
                {
                    Id = 1,
                    Title = "Beispielkurs 1",
                    Description = "Beschreibung des Beispielkurses 1",
                    ImageUrl = "url_zum_bild_1",
                    PaymentType = "Kostenlos",
                    Category = new Category { Id = 1, Name = "Beispielkategorie" },
                    Progress = 0,
                    Questions = questions.Take(3).ToList()
                },
                new()
                {
                    Id = 2,
                    Title = "Beispielkurs 2",
                    Description = "Beschreibung des Beispielkurses 2",
                    ImageUrl = "url_zum_bild_2",
                    PaymentType = "Premium",
                    Category = new Category { Id = 2, Name = "Weitere Kategorie" },
                    Progress = 0,
                    Questions = questions.Skip(3).Take(3).ToList()
                }*/
                new()
                {
                    Id = 2,
                    Title = "Beispielkurs 2",
                    Description = "Beschreibung des Beispielkurses 2",
                    ImageUrl = "url_zum_bild_2",
                    PaymentType = "Premium",
                    Category = new Category { Id = 2, Name = "Weitere Kategorie" },
                    Progress = 0,
                    Questions = new List<Question>
                    {
                        new()
                        {
                            Id = 9,
                            Content = "Wie lautet die Tastenkombination zum Kopieren?",
                            Shortcut = "Strg+C",
                            Result = QuestionResult.Correct,
                            QuestionsParameter = new List<QuestionParameter>
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
                            Id = 8,
                            Content = "Wie speichert man ein Dokument mit einer Tastenkombination?",
                            Shortcut = "Strg+S",
                            Result = QuestionResult.Correct,
                            QuestionsParameter = new List<QuestionParameter>
                            {
                                new()
                                {
                                    CourseID = 2,
                                    Language = "de_de",
                                    OperatingSystem = "Linux",
                                    KeyboadLayout = "QWERTZ"
                                }
                            }
                        }
                    }
                },
                new()
                {
                    Id = 3,
                    Title = "Beispielkurs 3",
                    Description = "Beschreibung des Beispielkurses 3",
                    ImageUrl = "url_zum_bild_2",
                    PaymentType = "Premium",
                    Category = new Category { Id = 3, Name = "Weitere Kategorie" },
                    Progress = 0,
                    //Questions = questions.Skip(3).Take(3).ToList()
                    Questions = new List<Question>
                    {
                        new()
                        {
                            Id = 7,
                            Content = "Wie öffnet man die Entwicklertools im Browser?",
                            Shortcut = "Strg+C",
                            Result = QuestionResult.Unanswered,
                            QuestionsParameter = new List<QuestionParameter>
                            {
                                new()
                                {
                                    CourseID = 3,
                                    Language = "en_en",
                                    OperatingSystem = "Windows",
                                    KeyboadLayout = "QWERTZ"
                                }
                            }
                        },
                    }
                }
            };
        }

        public List<Course> DataStore { get; }

        public async Task<IEnumerable<Course>> GetDataAsync()
        {
            return await Task.FromResult(DataStore.AsEnumerable());
        }

        public async Task SetDataAsync(IEnumerable<Course> data)
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
