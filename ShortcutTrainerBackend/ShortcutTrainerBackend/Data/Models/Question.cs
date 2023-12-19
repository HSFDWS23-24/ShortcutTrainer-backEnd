using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

[Persistent("question")]
public class Question : XPLiteObject
{
    public Question(Session session) : base(session) { }

    [Persistent("id"), Key(AutoGenerate = true)]
    public int Id;

    [Persistent("course_id"), Association("Course-Question")]
    public Course Course
    {
        get => fCourse;
        set => SetPropertyValue(nameof(Course), ref fCourse, value);
    }
    private Course fCourse;

    [Persistent("content"), Size(128)]
    public string Content
    {
        get => fContent;
        set => SetPropertyValue(nameof(Content), ref fContent, value);
    }
    private string fContent;

    [Association("Question-Answer")]
    public XPCollection<Answer> Answers => new XPCollection<Answer>();
}