using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PreferredLanguage { get; set; }

    public string PreferredKeyboardLayout { get; set; }

    public string PreferredOperatingSystem { get; set; }

    public List<UserCourse> UserCourses { get; set; }
}