using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string Language { get; set; }

    public string Description { get; set; }
    
    public string ImageUrl { get; set; }

    public SubscriptionType Subscription { get; set; }

    public List<CourseTag> Tags { get; set; }

    // public List<UserCourse> UserCourses { get; set; }
}

public enum SubscriptionType
{
    Free,
    Other
}