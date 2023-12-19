namespace ShortcutTrainerBackend.Data.TransferObjects;

public class DtoUser
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? PreferredLanguage { get; set; }
    public string? PreferredOperatingSystem { get; set; }
    public string? PreferredKeyboardLayout { get; set; }
}