using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public struct UserCourseKey
{
    [Persistent("user_id"), Association("User-UserCourse")]
    public User User { get; set; }

    [Persistent("course_id"), Association("Course-UserCourse")]
    public Course Course { get; set; }
}

[Persistent("user_course")]
public class UserCourse : XPLiteObject
{
    public UserCourse(Session session) : base(session) { }

    [Key, Persistent]  
    public UserCourseKey Key {get; set;}  

    [Persistent("favorite")]
    public bool Favorite
    {
        get => fFavorite;
        set => SetPropertyValue(nameof(Favorite), ref fFavorite, value);
    }
    private bool fFavorite;
}