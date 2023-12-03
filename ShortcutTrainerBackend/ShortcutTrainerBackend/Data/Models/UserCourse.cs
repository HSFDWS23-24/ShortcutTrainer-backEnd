using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class UserCourse
{
    public User User { get; set; }
    
    public Course Course { get; set; }
    
    public bool Favorite { get; set; }
}