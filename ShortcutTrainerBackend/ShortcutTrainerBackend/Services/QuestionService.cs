using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMockDatabase<Course> _mockDatabase;
        public QuestionService(IMockDatabase<Course> mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public async Task<IEnumerable<Question>> GetQuestionsAsync(QuestionParameter request)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == request.CourseID);

            if (course != null)
            {
                // return await Task.FromResult(course.Questions.AsEnumerable());
                return await Task.FromResult(new List<Question>());
            }
            return await Task.FromResult(Enumerable.Empty<Question>());
        }
    }
}
