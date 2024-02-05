namespace ShortcutTrainerBackend.Data.Models
{
    public class UserCourseParameter
    {
        public required string? UserID { get; set; }
        public int CourseID { get; set; }
        public bool Favorite { get; set; }
    }
}
