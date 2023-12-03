using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PreferedLanguage { get; set; }

    public string PreferedKeyboardLayout { get; set; }

    public string PreferedOperatingSystem { get; set; }

    public List<UserCourse> UserCourses { get; set; }
}