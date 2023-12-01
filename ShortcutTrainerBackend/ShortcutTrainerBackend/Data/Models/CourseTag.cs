using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

// [Persistent("course_tag")]
public class CourseTag : XPLiteObject
{
    public CourseTag(Session session) : base(session) { }
    public CourseTag() : base(XpoDefault.Session) { }

    // [Persistent("course_id"), Association("CourseTags")]
    public Course Course
    {
        get => GetPropertyValue<Course>();
        set => SetPropertyValue(nameof(Course), value);
    }

    // [Persistent("tag"), Size(50)]
    public string Tag
    {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(nameof(Tag), value);
    }
}