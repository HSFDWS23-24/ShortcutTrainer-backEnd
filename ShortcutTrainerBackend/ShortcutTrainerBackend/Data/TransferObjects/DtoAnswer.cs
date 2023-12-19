namespace ShortcutTrainerBackend.Data.TransferObjects;

public class DtoAnswer
{
    public required int Id { get; set; }
    public required string System { get; set; }
    public required string Shortcut { get; set; }
}