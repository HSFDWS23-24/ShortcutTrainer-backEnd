namespace ShortcutTrainerBackend.Data.Models
{
    public class QuestionParameter
    {        
        public required int CourseID { get; set; }
        public required string Language { get; set; }
        public required string OperatingSystem { get; set; }
        public required string KeyboadLayout { get; set; }
    }
}
