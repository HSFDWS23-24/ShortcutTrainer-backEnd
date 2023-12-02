using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

// [Persistent("course")]
public class Course : XPLiteObject
{
    public Course(Session session) : base(session) { }
    public Course() : base(XpoDefault.Session) { }
    
    // [Persistent("id"), Key(AutoGenerate = true)]
    public int Id;

    // [Persistent("title"), Size(128)]
    public string Title
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Title), value);
    }

    // [Persistent("language"), Size(2)]
    public string Language
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Language), value);
    }

    // [Persistent("description")]
    public string Description
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Description), value);
    }

    // [Persistent("image_url"), Size(128)]
    public string ImageUrl
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(ImageUrl), value);
    }

    // [Persistent("subscription")]
    public SubscriptionType Subscription
    {
        get => GetPropertyValue<SubscriptionType>();
        set => SetPropertyValue(nameof(Subscription), value);
    }

    // [Association("CourseTags")]
    public XPCollection<CourseTag> Tags => GetCollection<CourseTag>();
    
    // [Association("UserCourses-Courses")]
    public XPCollection<UserCourse> UserCourses => GetCollection<UserCourse>();
}

public enum SubscriptionType
{
    Free,
    Other
}