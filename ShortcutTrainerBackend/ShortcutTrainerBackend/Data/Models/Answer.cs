using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

// [Persistent("answer")]
public class Answer : XPLiteObject
{
    public Answer(Session session) : base(session) { }
    public Answer() : base(XpoDefault.Session) { }

    // [Persistent("id"), Key(AutoGenerate = true)]
    public int Id;

    // [Persistent("question_id"), Association("Answers")]
    public Question Question
    {
        get => GetPropertyValue<Question>();
        set => SetPropertyValue(nameof(Question), value);
    }

    // [Persistent("system"), Size(16)]
    public string System
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(System), value);
    }

    // [Persistent("shortcut"), Size(SizeAttribute.Unlimited)]
    public string Shortcut
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Shortcut), value);
    }
}