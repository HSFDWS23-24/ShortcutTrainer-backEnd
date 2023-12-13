using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public struct CourseTagKey
{
    [Persistent("course_id"), Association("Course-CourseTag")]
    public Course Course { get; set; }

    [Persistent("tag"), Size(50)]
    public string Tag { get; set; }
}

[Persistent("course_tag")]
public class CourseTag : XPLiteObject
{
    public CourseTag(Session session) : base(session) { }

    [Key, Persistent]
    public CourseTagKey Key;
}