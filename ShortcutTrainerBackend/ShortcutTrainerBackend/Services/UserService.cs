using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class UserService : IUserService
    {
        private readonly IMockDatabase<Course> _mockDatabase;

        public UserService(IMockDatabase<Course> mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        public async Task<IEnumerable<Question>> GetUnansweredQuestionsAsync(int courseId, string language, string keyboardLayout)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {

                var unansweredQuestions = course.Questions.Where(q => q.Result == QuestionResult.Unanswered && q.QuestionsParameter.Any(param =>
                                                   param.Language == language &&
                                                   param.KeyboadLayout == keyboardLayout));

                return await Task.FromResult(unansweredQuestions.AsEnumerable());
            }

            return await Task.FromResult(Enumerable.Empty<Question>());
        }

        public async Task<IEnumerable<Question>> GetIncorrectQuestionsAsync(int courseId, string language, string keyboardLayout)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {

                var incorrectQuestions = course.Questions.Where(q => q.Result == QuestionResult.Incorrect && q.QuestionsParameter.Any(param =>
                                                   param.Language == language &&
                                                   param.KeyboadLayout == keyboardLayout));


                return await Task.FromResult(incorrectQuestions.AsEnumerable());
            }

            return await Task.FromResult(Enumerable.Empty<Question>());
        }

        public async Task<IEnumerable<Question>> GetCorrectQuestionsAsync(int courseId, string language, string keyboardLayout)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {

                var correctQuestions = course.Questions.Where(q => q.Result == QuestionResult.Correct && q.QuestionsParameter.Any(param =>
                                                   param.Language == language &&
                                                   param.KeyboadLayout == keyboardLayout));

                return await Task.FromResult(correctQuestions.AsEnumerable());
            }

            return await Task.FromResult(Enumerable.Empty<Question>());
        }

        //Update Answer
        public async Task UpdateAnswerStatusAsync(int questionId, QuestionResult result)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Questions.Any(q => q.Id == questionId));

            if (course != null)
            {
                var question = course.Questions.FirstOrDefault(q => q.Id == questionId);
                if (question != null)
                {
                    question.Result = result;
                }
            }

            await _mockDatabase.SaveChangesAsync();
        }
    }
}
