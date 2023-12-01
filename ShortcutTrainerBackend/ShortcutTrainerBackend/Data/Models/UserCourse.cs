using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

// [Persistent("user_course")]
public class UserCourse : XPLiteObject
{
    public UserCourse(Session session) : base(session) { }
    public UserCourse() : base(XpoDefault.Session) { }

    // [Persistent("user_id"), Association("UserCourses-Users")]
    public User User
    {
        get => GetPropertyValue<User>();
        set => SetPropertyValue(nameof(User), value);
    }

    // [Persistent("course_id"), Association("UserCourses-Courses")]
    public Course Course
    {
        get => GetPropertyValue<Course>();
        set => SetPropertyValue(nameof(Course), value);
    }

    // [Persistent("favorite")]
    public bool Favorite
    {
        get => GetPropertyValue<bool>();
        set => SetPropertyValue(nameof(Favorite), value);
    }
}