namespace ShortcutTrainerBackend.Data.Models
{
    public class UserParameter
    {
        public required string? UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PreferredLanguage { get; set; }
        public string? PreferredOperatingSystem { get; set; }
        public string? PreferredKeyboardLayout { get; set; }
    }
}
