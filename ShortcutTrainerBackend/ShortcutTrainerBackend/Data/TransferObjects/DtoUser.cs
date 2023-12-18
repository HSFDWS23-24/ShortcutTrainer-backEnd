namespace ShortcutTrainerBackend.Data.TransferObjects;

public class DtoUser
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}