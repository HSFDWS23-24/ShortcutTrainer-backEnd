using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class CourseService : ICourseService
    {
        public async Task<IEnumerable<Course>> GetCoursesAsync(CourseParameter request)
        {

            // request einthält Parameter um die erwüschten Kurse herauszufiltern
            // dazu aber am besten Datenbank

            var courses = new List<Course>
            {
                new Course {ID = 1, CourseTitle = "Mac", Description = "Eine Bechreibung", 
                    ImageURL = "https://google.com", Type = "Free", Category = "OS",
                    Progress = "35"},
                new Course {ID = 2, CourseTitle = "Mac", Description = "Eine Bechreibung",
                    ImageURL = "https://google.com", Type = "Free", Category = "OS",
                    Progress = "35"}
            };

            return await Task.FromResult(courses);
        }
    }
}
