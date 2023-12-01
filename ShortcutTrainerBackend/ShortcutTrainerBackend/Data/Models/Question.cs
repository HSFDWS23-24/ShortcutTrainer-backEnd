using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

// [Persistent("question")]
public class Question : XPLiteObject
{
    public Question(Session session) : base(session) { }
    public Question() : base(XpoDefault.Session) { }

    // [Persistent("id"), Key(AutoGenerate = true)]
    public int Id;

    // [Persistent("course_id"), Association("Questions")]
    public Course Course
    {
        get => GetPropertyValue<Course>();
        set => SetPropertyValue(nameof(Course), value);
    }

    // [Persistent("content"), Size(128)]
    public string Content
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Content), value);
    }

    // [Association("Answers")]
    public XPCollection<Answer> Answers => GetCollection<Answer>();
}