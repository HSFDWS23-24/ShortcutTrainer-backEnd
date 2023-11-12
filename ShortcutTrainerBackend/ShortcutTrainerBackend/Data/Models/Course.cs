namespace ShortcutTrainerBackend.Data.Models
{
    public class Course
    {
        public required int ID { get; set; }
        public required string CourseTitle { get; set; }
        public required string Description { get; set; }
        public required string ImageURL { get; set; }
        public required string Type { get; set;}
        public required string Category { get; set; }
        public required string Progress { get; set; }

    }
}
