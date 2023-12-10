using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShortcutTrainerBackend.Data.Models;
using ShortcutTrainerBackend.Testing.Mocks.Interfaces;

namespace ShortcutTrainerBackend.Testing.Mocks.Data
{
    public class MockUserAnswerDatabase : IMockDatabase<UserAnswer>
    {
        public List<UserAnswer> DataStore { get; }

        public MockUserAnswerDatabase(IMockDatabase<Course> courseDatabase)
        {

            var courses = courseDatabase.GetDataAsync().Result.ToList();
            DataStore = new List<UserAnswer>
            {
                new UserAnswer
                {
                    User = new User
                    {
                        Id = "1",
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        UserCourses = new List<UserCourse>()
                    },
                    Answer = new Answer
                    {
                        Id = 1,
                        Question = new Question
                        {
                            Id = 1,
                            Course = courses[0],
                            Content = "Wie kopiere ich?"
                        },
                        System = "Windows",
                        Shortcut = "Ctrl+C"
                    },
                    QuestionStatus = QuestionStatusType.Correct
                },
                new UserAnswer
                {
                    User = new User
                    {
                        Id = "2",
                        Name = "Jane Doe",
                        Email = "jane.doe@example.com",
                        UserCourses = new List<UserCourse>()
                    },
                    Answer = new Answer
                    {
                        Id = 2,
                        Question = new Question
                        {
                            Id = 2,
                            Course = courses[0],
                            Content = "Wie füge ich ein?"
                        },
                        System = "Mac",
                        Shortcut = "Cmd+V"
                    },
                    QuestionStatus = QuestionStatusType.Incorrect
                },
                new UserAnswer
                {
                    User = new User
                    {
                        Id = "3",
                        Name = "Bob Smith",
                        Email = "bob.smith@example.com",
                        UserCourses = new List<UserCourse>()
                    },
                    Answer = new Answer
                    {
                        Id = 3,
                        Question = new Question
                        {
                            Id = 3,
                            Course = courses[2],
                            Content = "Wie speichere ich?"
                        },
                        System = "Linux",
                        Shortcut = "Ctrl+S"
                    },
                    QuestionStatus = QuestionStatusType.Correct
                },
                new UserAnswer
                {
                    User = new User
                    {
                        Id = "4",
                        Name = "Alice Johnson",
                        Email = "alice.johnson@example.com",
                        UserCourses = new List<UserCourse>()
                    },
                    Answer = new Answer
                    {
                        Id = 4,
                        Question = new Question
                        {
                            Id = 4,
                            Course = courses[3],
                            Content = "Wie öffne ich ein neues Dokument?"
                        },
                        System = "Windows",
                        Shortcut = "Ctrl+N"
                    },
                    QuestionStatus = QuestionStatusType.Incorrect
                },
                new UserAnswer
                {
                    User = new User
                    {
                        Id = "1",
                        Name = "John Doe",
                        Email = "john.doe@example.com",
                        UserCourses = new List<UserCourse>()
                    },
                    Answer = new Answer
                    {
                        Id = 5,
                        Question = new Question
                        {
                            Id = 5,
                            Course = courses[0],
                            Content = "Wie speichere ich?"
                        },
                        System = "Linux",
                        Shortcut = "Ctrl+S"
                    },
                    QuestionStatus = QuestionStatusType.Correct
                }
            };
        }

        public async Task<IEnumerable<UserAnswer>> GetDataAsync()
        {
            return await Task.FromResult(DataStore.AsEnumerable());
        }

        public async Task SetDataAsync(IEnumerable<UserAnswer> data)
        {
            await Task.Delay(2000); // wait 2 seconds before returning any Status
            DataStore.AddRange(data);
            await Task.CompletedTask;
        }
    }
}