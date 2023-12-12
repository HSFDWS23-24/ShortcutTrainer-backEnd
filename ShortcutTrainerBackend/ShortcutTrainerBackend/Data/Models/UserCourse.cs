using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class UserCourse
{
    public string UserId { get; set; }
    public User User { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    public bool Favorite { get; set; }
}