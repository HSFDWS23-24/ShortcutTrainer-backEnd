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

    // [Persistent("preferred_language"), Size(128)]
    // public string PreferredLanguage
    // {
    //     get => fPreferredLanguage;
    //     set => SetPropertyValue(nameof(PreferredLanguage), ref fPreferredLanguage, value);
    // }
    // private string fPreferredLanguage;

    // [Persistent("preferred_keyboard_layout"), Size(128)]
    // public string PreferredKeyboardLayout
    // {
    //     get => fPreferredKeyboardLayout;
    //     set => SetPropertyValue(nameof(PreferredKeyboardLayout), ref fPreferredKeyboardLayout, value);
    // }
    // private string fPreferredKeyboardLayout;

    // [Persistent("preferred_operating_system"), Size(128)]
    // public string PreferredOperatingSystem
    // {
    //     get => fPreferredOperatingSystem;
    //     set => SetPropertyValue(nameof(PreferredOperatingSystem), ref fPreferredOperatingSystem, value);
    // }
    //private string fPreferredOperatingSystem;

    [Association("User-UserCourse")]
    public XPCollection<UserCourse> UserCourses => GetCollection<UserCourse>();

    [Association("User-UserAnswer")]
    public XPCollection<UserAnswer> UserAnswers => GetCollection<UserAnswer>();
}