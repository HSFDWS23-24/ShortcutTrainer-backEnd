using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

// [Persistent("user_answer")]
public class UserAnswer : XPLiteObject
{
    public UserAnswer(Session session) : base(session) { }

    // [Persistent("user_id"), Association("UserAnswers")]
    public User User
    {
        get => GetPropertyValue<User>();
        set => SetPropertyValue(nameof(User), value);
    }

    // [Persistent("answer_id"), Association("UserAnswers")]
    public Answer Answer
    {
        get => GetPropertyValue<Answer>();
        set => SetPropertyValue(nameof(Answer), value);
    }

    // [Persistent("question_status")]
    public QuestionStatusType QuestionStatus
    {
        get => GetPropertyValue<QuestionStatusType>();
        set => SetPropertyValue(nameof(QuestionStatus), value);
    }
}

public enum QuestionStatusType
{
    Correct,
    Incorrect,
    Unanswered
}