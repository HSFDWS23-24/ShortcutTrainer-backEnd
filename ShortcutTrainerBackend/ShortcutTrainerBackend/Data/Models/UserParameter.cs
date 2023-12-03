namespace ShortcutTrainerBackend.Data.Models
{
    public class UserParameter
    {
        public required string? UserID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PreferedLanguage { get; set; }
        public string? PreferedOperatingSystem { get; set; }
        public string? PreferedKeyboardLayout { get; set; }
    }
}
