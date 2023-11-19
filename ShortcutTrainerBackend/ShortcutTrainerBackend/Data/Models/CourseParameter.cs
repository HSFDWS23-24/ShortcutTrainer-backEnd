namespace ShortcutTrainerBackend.Data.Models
{
    public class CourseParameter
    {
        public int UserID { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public string OperatingSystem { get; set; }
        public string SearchString { get; set; }
        public required int Limit { get; set; }
    }
}
