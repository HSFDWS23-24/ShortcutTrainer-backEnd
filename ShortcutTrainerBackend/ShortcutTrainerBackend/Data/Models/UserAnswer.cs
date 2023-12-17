using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public struct UserAnswerKey
{
    [Persistent("user_id"), Association("User-UserAnswer")]
    public User User { get; set; }

    [Persistent("answer_id"), Association("Answer-UserAnswer")]
    public Answer Answer { get; set; }
}

[Persistent("user_answer")]
public class UserAnswer : XPLiteObject
{
    public UserAnswer(Session session) : base(session) { }
    
    [Key, Persistent]  
    public UserAnswerKey Key {get; set;}  

    [Persistent("question_status")]
    public string QuestionStatus
    {
        get => fQuestionStatus;
        set => SetPropertyValue(nameof(QuestionStatus), ref fQuestionStatus, value);
    }
    private string fQuestionStatus;
}