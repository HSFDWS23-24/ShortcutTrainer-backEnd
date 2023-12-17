using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

[Persistent("course")]
public class Course : XPLiteObject
{
    public Course(Session session) : base(session) { }
    
    [Persistent("id"), Key(AutoGenerate = true)]
    public int Id;

    [Persistent("title"), Size(128)]
    public string Title
    {
        get => fTitle;
        set => SetPropertyValue(nameof(Title), ref fTitle, value);
    }
    private string fTitle;

    [Persistent("language"), Size(2)]
    public string Language
    {
        get => fLanguage;
        set => SetPropertyValue(nameof(Language), ref fLanguage, value);
    }
    private string fLanguage;

    [Persistent("description")]
    public string Description
    {
        get => fDescription;
        set => SetPropertyValue(nameof(Description), ref fDescription, value);
    }
    private string fDescription;

    [Persistent("image_url"), Size(128)]
    public string ImageUrl
    {
        get => fImageUrl;
        set => SetPropertyValue(nameof(ImageUrl), ref fImageUrl, value);
    }
    private string fImageUrl;

    [Persistent("subscription")]
    public string Subscription
    {
        get => fSubscription;
        set => SetPropertyValue(nameof(Subscription), ref fSubscription, value);
    }
    private string fSubscription;

    [Association("Course-CourseTag")]
    public XPCollection<CourseTag> Tags => GetCollection<CourseTag>();
    
    [Association("Course-UserCourse")]
    public XPCollection<UserCourse> UserCourses => GetCollection<UserCourse>();

    [Association("Course-Question")]
    public XPCollection<Question> Questions => GetCollection<Question>();
}