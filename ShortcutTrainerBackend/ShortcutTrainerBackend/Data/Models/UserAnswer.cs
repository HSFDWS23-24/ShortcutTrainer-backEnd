using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class UserAnswer
{
    public User User { get; set; }

    public Answer Answer { get; set; }
    
    public QuestionStatusType QuestionStatus { get; set; }
}

public enum QuestionStatusType
{
    Correct,
    Incorrect,
    Unanswered
}