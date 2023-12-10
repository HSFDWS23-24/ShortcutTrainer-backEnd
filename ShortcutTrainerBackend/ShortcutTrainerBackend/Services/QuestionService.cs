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

            if (course == null)
                return await Task.FromResult(Enumerable.Empty<Question>());
            
            return await Task.FromResult(course.Questions);
        }

        public async Task<IEnumerable<Question>> GetUnansweredQuestionsAsync(QuestionParameter request)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == request.CourseID);

            if (course == null)
                return await Task.FromResult(Enumerable.Empty<Question>());
            
            return await Task.FromResult(course.Questions.Where(q => q.Status == QuestionStatus.Unanswered));
        }

        public async Task<IEnumerable<Question>> GetIncorrectQuestionsAsync(QuestionParameter request)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == request.CourseID);

            if (course == null)
                return await Task.FromResult(Enumerable.Empty<Question>());
            
            return await Task.FromResult(course.Questions.Where(q => q.Status == QuestionStatus.Incorrect));
        }

        public async Task<IEnumerable<Question>> GetCorrectQuestionsAsync(QuestionParameter request)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == request.CourseID);

            if (course == null)
                return await Task.FromResult(Enumerable.Empty<Question>());
            
            return await Task.FromResult(course.Questions.Where(q => q.Status == QuestionStatus.Correct));
        }

        public async Task UpdateQuestionStatusAsync(int questionId, QuestionStatus result)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Questions.Any(q => q.Id == questionId));

            if (course == null)
                return;
            
            var question = course.Questions.FirstOrDefault(q => q.Id == questionId);
            if (question != null)
            {
                question.Status = result;
            }

            await _mockDatabase.SetDataAsync(_mockDatabase.DataStore);
        }
    }
}
