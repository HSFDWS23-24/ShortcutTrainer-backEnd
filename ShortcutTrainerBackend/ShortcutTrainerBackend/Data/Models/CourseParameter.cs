namespace ShortcutTrainerBackend.Data.Models
{
    public class CourseParameter
    {
        public string? UserID { get; set; }
        public string? Tag { get; set; }
        public string? Language { get; set; }
        public SubscriptionType? SubscriptionType { get; set; }
        public string? SearchString { get; set; }
        public int? Limit { get; set; }
    }
}
