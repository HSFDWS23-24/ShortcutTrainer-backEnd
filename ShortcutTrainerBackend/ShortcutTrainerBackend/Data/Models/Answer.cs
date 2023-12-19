using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

[Persistent("answer")]
public class Answer : XPLiteObject
{
    public Answer(Session session) : base(session) { }

    [Persistent("id"), Key(AutoGenerate = true)]
    public int Id;

    [Persistent("question_id"), Association("Question-Answer")]
    public Question Question
    {
        get => fQuestion;
        set => SetPropertyValue(nameof(Question), ref fQuestion, value);
    }
    private Question fQuestion;

    [Persistent("system"), Size(16)]
    public string System
    {
        get => fSystem;
        set => SetPropertyValue(nameof(fSystem), ref fSystem, value);
    }
    private string fSystem;

    [Persistent("shortcut"), Size(SizeAttribute.Unlimited)]
    public string Shortcut
    {
        get => fShortcut;
        set => SetPropertyValue(nameof(fShortcut), ref fShortcut, value);
    }
    private string fShortcut;
    
    [Association("Answer-UserAnswer")]
    public XPCollection<UserAnswer> UserAnswers => GetCollection<UserAnswer>();
}