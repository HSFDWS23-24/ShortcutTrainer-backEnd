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

        public IEnumerable<DtoQuestion> GetQuestions(int courseId, string language, string system)
        {
            var questions = new XPCollection<Question>(_session)
                .Where(q => q.Course.Id == courseId && q.Course.Language == language)
                .Select(q => new DtoQuestion
                {
                    Id = q.Id,
                    Content = q.Content,
                    Answers = q.Answers
                        .Where(a => a.System == system)
                        .Select(a => new DtoAnswer
                        {
                            Id = a.Id,
                            System = a.System,
                            Shortcut = a.Shortcut
                        })
                });
            return questions;
        }

        public async Task<IEnumerable<DtoQuestion>> GetQuestionsAsync(int courseId, string language, string system)
        {
            return await Task.FromResult(GetQuestions(courseId, language, system));
        }

        public IEnumerable<DtoQuestion> GetUnansweredQuestions(int courseId, string language, string system, string userId)
        {
            var questions = new XPCollection<Question>(_session)
                .Where(q => q.Course.Id == courseId && q.Course.Language == language)
                .Select(q => new DtoQuestion
                {
                    Id = q.Id,
                    Content = q.Content,
                    Answers = q.Answers
                        .Where(a => a.System == system)
                        .Select(a => new DtoAnswer
                        {
                            Id = a.Id,
                            System = a.System,
                            Shortcut = a.Shortcut
                        })
                }).Where(q =>
            q.Answers.Any() &&
            q.Answers.All(a =>
                _session.Query<UserAnswer>()
                    .Any(ua => ua.Key.User.Id == userId && ua.Key.Answer.Id == a.Id && ua.QuestionStatus == "Unanswered")
            )
        );
            return questions;
        }

        public async Task<IEnumerable<DtoQuestion>> GetUnansweredQuestionsAsync(int courseId, string language, string system, string userId)
        {
            return await Task.FromResult(GetUnansweredQuestions(courseId, language, system, userId));
        }

        public IEnumerable<DtoQuestion> GetIncorrectQuestions(int courseId, string language, string system, string userId)
        {
            var questions = new XPCollection<Question>(_session)
                .Where(q => q.Course.Id == courseId && q.Course.Language == language)
                .Select(q => new DtoQuestion
                {
                    Id = q.Id,
                    Content = q.Content,
                    Answers = q.Answers
                        .Where(a => a.System == system)
                        .Select(a => new DtoAnswer
                        {
                            Id = a.Id,
                            System = a.System,
                            Shortcut = a.Shortcut
                        })
                }).Where(q =>
            q.Answers.Any() &&
            q.Answers.All(a =>
                _session.Query<UserAnswer>()
                    .Any(ua => ua.Key.User.Id == userId && ua.Key.Answer.Id == a.Id && ua.QuestionStatus == "Incorrect")
            )
        );
            return questions;
        }

        public async Task<IEnumerable<DtoQuestion>> GetIncorrectQuestionsAsync(int courseId, string language, string system, string userId)
        {
            return await Task.FromResult(GetIncorrectQuestions(courseId, language, system, userId));
        }

        public IEnumerable<DtoQuestion> GetCorrectQuestions(int courseId, string language, string system, string userId)
        {
            var questions = new XPCollection<Question>(_session)
                .Where(q => q.Course.Id == courseId && q.Course.Language == language)
                .Select(q => new DtoQuestion
                {
                    Id = q.Id,
                    Content = q.Content,
                    Answers = q.Answers
                        .Where(a => a.System == system)
                        .Select(a => new DtoAnswer
                        {
                            Id = a.Id,
                            System = a.System,
                            Shortcut = a.Shortcut
                        })
                }).Where(q =>
            q.Answers.Any() &&
            q.Answers.All(a =>
                _session.Query<UserAnswer>()
                    .Any(ua => ua.Key.User.Id == userId && ua.Key.Answer.Id == a.Id && ua.QuestionStatus == "Correct")
            )
        );
            return questions;
        }

        public async Task<IEnumerable<DtoQuestion>> GetCorrectQuestionsAsync(int courseId, string language, string system, string userId)
        {
            return await Task.FromResult(GetCorrectQuestions(courseId, language, system, userId));
        }

        public async Task UpdateQuestionStatusAsync(int questionId, string userId, string questionStatus)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(_session.DataLayer))
                {
                    var question = await Task.Run(() => unitOfWork.GetObjectByKey<Question>(questionId));

                    if (question != null)
                    {
                        var answer = question.Answers.FirstOrDefault();

                        if (answer != null)
                        {
                            var userAnswer = await Task.Run(() =>
                                unitOfWork.Query<UserAnswer>()
                                    .FirstOrDefault(ua =>
                                        ua.Key.User.Id == userId &&
                                        ua.Key.Answer.Id == answer.Id
                                    ));

                            if (userAnswer != null)
                            {
                                userAnswer.QuestionStatus = questionStatus;

                                // Commit der Transaktion
                                await Task.Run(() => unitOfWork.CommitChanges());
                            }
                            else
                            {
                                throw new ArgumentException($"Keine Benutzerantwort gefunden für Benutzer {userId} und Antwort {answer.Id}.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"Antwort nicht gefunden für die Frage {questionId}.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException($"Frage mit der ID {questionId} wurde nicht gefunden.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Aktualisieren des Fragestatus: {ex}");
                throw;
            }
        }
    }
}
