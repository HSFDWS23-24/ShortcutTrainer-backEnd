using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

// [Persistent("_user")]
public class User : XPLiteObject
{
    public User(Session session) : base(session) { }
    public User() : base(XpoDefault.Session) { }

    // [Persistent("id"), Key(AutoGenerate = false), Size(36)]
    public string Id
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Id), value);
    }

    // [Persistent("name"), Size(128)]
    public string Name
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Name), value);
    }

    // [Persistent("email"), Size(320)]
    public string Email
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Email), value);
    }

    // [Association("UserCourses-Users")]
    public XPCollection<UserCourse> UserCourses => GetCollection<UserCourse>();
}