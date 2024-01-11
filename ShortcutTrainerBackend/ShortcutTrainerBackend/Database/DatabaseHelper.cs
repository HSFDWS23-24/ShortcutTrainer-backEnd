using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Newtonsoft.Json;
using ShortcutTrainerBackend.Data.Models;

namespace ShortcutTrainerBackend.Database;

public static class DatabaseHelper
{
    public static void CreateDatabaseConnection()
    {
        var databaseConfig = GetDatabaseConfig();

        if (databaseConfig == null)
        {
            Console.WriteLine("Unable to evaluate database config.");
            return;
        }
        
        var connectionString = PostgreSqlConnectionProvider.GetConnectionString(
            server: databaseConfig.Server,
            port: databaseConfig.Port,
            userId: databaseConfig.UserId,
            password: databaseConfig.Password,
            database: databaseConfig.Database
        );
        
        XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.None);
    }

    private static DatabaseConfig? GetDatabaseConfig()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Database", "config.json");
        DatabaseConfig? databaseConfig = null;
        try
        {
            var jsonText = File.ReadAllText(filePath);
            databaseConfig = JsonConvert.DeserializeObject<DatabaseConfig>(jsonText);
        }
        catch (Exception ex)
        {
            var configTemplate = """
                                 {
                                   "server": "your_server",
                                   "port": 5432,
                                   "userId": "your_user_id",
                                   "password": "your_password",
                                   "database": "your_database"
                                 }
                                 """;
            Console.WriteLine($"Error reading config file: {ex.Message}\nJSON file for database configuration required (Database/config.json):\n{configTemplate}");
        }
        return databaseConfig;
    }
    
    public static void ShowDemo()
    {
        using var uow = new UnitOfWork();
        
        // delete all database values before inserting new ones for showing demo
        var tableNames = new List<string>
        {
            "user_answer",
            "user_course",
            "answer",
            "question",
            "course_tag",
            "course",
            "_user"
        };

        foreach (var deleteStatement in tableNames.Select(tableName => $"delete from {tableName};"))
        {
            Console.WriteLine($"({nameof(ShowDemo)}) Try execute: {deleteStatement}");
            uow.ExecuteNonQuery(deleteStatement);
            uow.CommitChanges();
        }
        
        // create and save test data
        var user1 = new User(uow)
        {
            Id = Guid.NewGuid().ToString(),
            Email = "user1@mail.com",
            Name = "User1",
            /*PreferredLanguage = "de-DE",
            PreferredKeyboardLayout = "QWERTZ",
            PreferredOperatingSystem = "Windows 10"*/
        };
        
        var user2 = new User(uow)
        {
            Id = Guid.NewGuid().ToString(),
            Email = "user2@mail.com",
            Name = "User2",
            // PreferredLanguage = "en-EN",
            // PreferredKeyboardLayout = "QWERTY",
            // PreferredOperatingSystem = "Linux"
        };

        var course = new Course(uow)
        {
            Title = "Test Course Title",
            Language = "de-DE",
            Description = "Some test description for Test Course",
            ImageUrl = "image3.jpg",
            Subscription = "free"
        };

        var courseTag1 = new CourseTag(uow)
        {
            Key = new CourseTagKey
            {
                Course = course,
                Tag = "TestCourseTag1"
            }
        };
        
        var courseTag2 = new CourseTag(uow)
        {
            Key = new CourseTagKey
            {
                Course = course,
                Tag = "TestCourseTag2"
            }
        };

        var userCourse1 = new UserCourse(uow)
        {
            Key = new UserCourseKey
            {
                Course = course,
                User = user1
            },
            Favorite = true
        };
        
        var userCourse2 = new UserCourse(uow)
        {
            Key = new UserCourseKey
            {
                Course = course,
                User = user2
            },
            Favorite = false
        };

        var question1 = new Question(uow)
        {
            Course = course,
            Content = "Test Question 1 content?"
        };
        
        var question2 = new Question(uow)
        {
            Course = course,
            Content = "Test Question 2 content?"
        };

        var answer11 = new Answer(uow)
        {
            Question = question1,
            System = "System1",
            Shortcut = "shortcut11"
        };
        
        var answer12 = new Answer(uow)
        {
            Question = question1,
            System = "System2",
            Shortcut = "shortcut12"
        };
        
        var answer21 = new Answer(uow)
        {
            Question = question2,
            System = "System1",
            Shortcut = "shortcut21"
        };
        
        var answer22 = new Answer(uow)
        {
            Question = question2,
            System = "System2",
            Shortcut = "shortcut22"
        };

        // register user1 for every answer linked to Test Course
        var userAnswer1 = new UserAnswer(uow)
        {
            Key = new UserAnswerKey
            {
                Answer = answer11,
                User = user1
            },
            QuestionStatus = "unanswered"
        };
        
        var userAnswer2 = new UserAnswer(uow)
        {
            Key = new UserAnswerKey
            {
                Answer = answer12,
                User = user1
            },
            QuestionStatus = "unanswered"
        };
        
        var userAnswer3 = new UserAnswer(uow)
        {
            Key = new UserAnswerKey
            {
                Answer = answer21,
                User = user1
            },
            QuestionStatus = "unanswered"
        };
        
        var userAnswer4 = new UserAnswer(uow)
        {
            Key = new UserAnswerKey
            {
                Answer = answer22,
                User = user1
            },
            QuestionStatus = "unanswered"
        };
        
        uow.CommitChanges();
    }
}

public class DatabaseConfig
{
    public required string Server { get; set; }
    public required int Port { get; set; }
    public required string UserId { get; set; }
    public required string Password { get; set; }
    public required string Database { get; set; }
}