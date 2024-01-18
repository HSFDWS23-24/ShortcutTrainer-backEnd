using DevExpress.Xpo;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Data.TransferObjects;
using ShortcutTrainerBackend.Services.Interfaces;

namespace ShortcutTrainerBackend.Services
{
    public class QuestionService : IQuestionService
    {
        public QuestionService(Session session)
        {
            _session = session;
        }

        private readonly Session _session;

        private List<DtoQuestion> GetQuestionsByStatus(string? userId, int courseId, string language, string system, string questionStatus)
        {
            // Retrieve all questions based on course and language
            var questions = _session.Query<Question>()
                .Where(q => q.Course.Id == courseId && q.Course.Language == language)
                .ToList();

            // Extract question IDs for further filtering
            var questionIds = questions.Select(q => q.Id).ToList();

            // Create a list to store filtered questions
            var filteredQuestions = questions
                .Select(q => new DtoQuestion
                {
                    Id = q.Id,
                    Content = q.Content,
                    Answers = _session.Query<Answer>()
                        .Where(a => questionIds.Contains(a.Question.Id) && a.System == system)
                        .Select(a => new DtoAnswer
                        {
                            Id = a.Id,
                            System = a.System,
                            Shortcut = a.Shortcut
                        })
                        .ToList()
                })
                .ToList();

            // If both userId and questionStatus are provided, filter questions based on user answers
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(questionStatus))
            {
                filteredQuestions = filteredQuestions
                    .Where(q => _session.Query<Answer>()
                        .Any(a => questionIds.Contains(a.Question.Id) &&
                                  a.System == system &&
                                  _session.Query<UserAnswer>()
                                      .Any(ua => ua.Key.User.Id == userId &&
                                                 ua.Key.Answer.Id == a.Id &&
                                                 ua.QuestionStatus == questionStatus)))
                    .ToList();
            }

            // Check for unanswered questions and add them to the filtered list
            var unansweredQuestions = questions
                .Where(q => !_session.Query<Answer>().Any(a => questionIds.Contains(a.Question.Id) && a.System == system))
                .Select(q => new DtoQuestion
                {
                    Id = q.Id,
                    Content = q.Content,
                    Answers = new List<DtoAnswer>()
                })
                .ToList();

            filteredQuestions.AddRange(unansweredQuestions);

            return filteredQuestions;
        }

        public IEnumerable<DtoQuestion> GetQuestions(string? userId, int courseId, string language, string system)
        {
            return GetQuestionsByStatus(userId, courseId, language, system, "");
        }

        public async Task<IEnumerable<DtoQuestion>> GetQuestionsAsync(string? userId, int courseId, string language, string system)
        {
            return await Task.FromResult(GetQuestions(userId, courseId, language, system));
        }

        public IEnumerable<DtoQuestion> GetUnansweredQuestions(string? userId, int courseId, string language, string system)
        {
            return GetQuestionsByStatus(userId, courseId, language, system, "Unanswered");
        }

        public async Task<IEnumerable<DtoQuestion>> GetUnansweredQuestionsAsync(string? userId, int courseId, string language, string system)
        {
            return await Task.FromResult(GetUnansweredQuestions(userId, courseId, language, system));
        }

        public IEnumerable<DtoQuestion> GetIncorrectQuestions(string? userId, int courseId, string language, string system)
        {
            return GetQuestionsByStatus(userId, courseId, language, system, "Incorrect");
        }

        public async Task<IEnumerable<DtoQuestion>> GetIncorrectQuestionsAsync(string? userId, int courseId, string language, string system)
        {
            return await Task.FromResult(GetIncorrectQuestions(userId, courseId, language, system));
        }

        public IEnumerable<DtoQuestion> GetCorrectQuestions(string? userId, int courseId, string language, string system)
        {
            return GetQuestionsByStatus(userId, courseId, language, system, "Correct");
        }

        public async Task<IEnumerable<DtoQuestion>> GetCorrectQuestionsAsync(string? userId, int courseId, string language, string system)
        {
            return await Task.FromResult(GetCorrectQuestions(userId, courseId, language, system));
        }

        public async Task<bool> UpdateQuestionStatusAsync(string? userId, int questionId, string questionStatus)
        {
            using (var unitOfWork = new UnitOfWork(_session.DataLayer))
            {
                var question = await Task.Run(() => unitOfWork.GetObjectByKey<Question>(questionId));

                // no question is found
                if (question == null)
                {
                    return false;
                }

                var answer = question.Answers.FirstOrDefault();

                // no answer is found
                if (answer == null)
                {
                    return false;
                }

                var userAnswer = await Task.Run(() =>
                    unitOfWork.Query<UserAnswer>()
                        .FirstOrDefault(ua =>
                            ua.Key.User.Id == userId &&
                            ua.Key.Answer.Id == answer.Id
                        ));

                // no useranswer is found
                if (userAnswer == null)
                {
                    return false;
                }

                userAnswer.QuestionStatus = questionStatus;

                await Task.Run(() => unitOfWork.CommitChanges());
                //await _session.SaveChangesAsync();

                return true;
            }
        }
    }
}