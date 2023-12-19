using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

[Persistent("_user")]
public class User : XPLiteObject
{
    public User(Session session) : base(session) { }

    [Persistent("id"), Key(AutoGenerate = false), Size(36)]
    public string Id
    {
        get => fId;
        set => SetPropertyValue(nameof(Id), ref fId, value);
    }
    private string fId;

    [Persistent("name"), Size(128)]
    public string Name
    {
        get => fName;
        set => SetPropertyValue(nameof(Name), ref fName, value);
    }
    private string fName;

    [Persistent("email"), Size(320)]
    public string Email
    {
        get => fEmail;
        set => SetPropertyValue(nameof(Email), ref fEmail, value);
    }
    private string fEmail;

    [Association("User-UserCourse")]
    public XPCollection<UserCourse> UserCourses => GetCollection<UserCourse>();
    
    [Association("User-UserAnswer")]
    public XPCollection<UserAnswer> UserAnswers => GetCollection<UserAnswer>();
}