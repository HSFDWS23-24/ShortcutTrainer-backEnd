using System;
using System.Collections.Generic;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Services.Interfaces;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                var questionsForCourse = course.Questions.Where(c => c.QuestionParameter.Any(c => c.CourseID == request.CourseID));
                return await Task.FromResult(questionsForCourse.AsEnumerable());
            }
            return await Task.FromResult(Enumerable.Empty<Question>());
        }

        public async Task<IEnumerable<Question>> GetUnansweredQuestions(int courseId, string language, string OperatingSystem)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                var unansweredQuestions = _mockDatabase.DataStore
                    .Where(c => c.Id == courseId) // Überprüfe die courseId
                    .SelectMany(course => course.Questions
                        .Where(q =>
                            q.Result == QuestionStatus.Unanswered &&
                            q.QuestionParameter.Any(param =>
                                param.CourseID == courseId && // Überprüfe auch die courseId in den Parametern
                                param.Language == language &&
                                param.OperatingSystem == OperatingSystem
                            )
                        )
                    );

                return await Task.FromResult(unansweredQuestions.AsEnumerable());
            }

            return await Task.FromResult(Enumerable.Empty<Question>());
        }

        public async Task<IEnumerable<Question>> GetIncorrectQuestions(int courseId, string language, string OperatingSystem)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                var incorrectQuestions = _mockDatabase.DataStore
                        .Where(c => c.Id == courseId) // Überprüfe die courseId
                        .SelectMany(course => course.Questions
                            .Where(q =>
                                q.Result == QuestionStatus.Incorrect &&
                                q.QuestionParameter.Any(param =>
                                    param.CourseID == courseId && // Überprüfe auch die courseId in den Parametern
                                    param.Language == language &&
                                    param.OperatingSystem == OperatingSystem
                                )
                            )
                        );

                return await Task.FromResult(incorrectQuestions.AsEnumerable());
            }

            return await Task.FromResult(Enumerable.Empty<Question>());
        }

        public async Task<IEnumerable<Question>> GetCorrectQuestions(int courseId, string language, string OperatingSystem)
        {
            var course = _mockDatabase.DataStore.FirstOrDefault(c => c.Id == courseId);

            if (course != null)
            {
                var correctQuestions = _mockDatabase.DataStore
                        .Where(c => c.Id == courseId) // Überprüfe die courseId
                        .SelectMany(course => course.Questions
                            .Where(q =>
                                q.Result == QuestionStatus.Correct &&
                                q.QuestionParameter.Any(param =>
                                    param.CourseID == courseId && // Überprüfe auch die courseId in den Parametern
                                    param.Language == language &&
                                    param.OperatingSystem == OperatingSystem
                                )
                            )
                        );

                return await Task.FromResult(correctQuestions.AsEnumerable());
            }

            return await Task.FromResult(Enumerable.Empty<Question>());
        }

        public async Task UpdateQuestionStatus(int questionId, QuestionStatus result)
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

            await _mockDatabase.SetDataAsync(_mockDatabase.DataStore);
        }
    }
}
