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
                new()
                {
                    Id = 1,
                    Title = "Beispielkurs 1",
                    Description = "Beschreibung des Beispielkurses 1",
                    ImageUrl = "url_zum_bild_1",
                    PaymentType = "Kostenlos",
                    Category = new Category { Id = 1, Name = "Beispielkategorie" },
                    Progress = 0,
                    Questions = questions.Take(5).ToList()
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
                    Questions = questions.Take(5).ToList()
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
    }
}
