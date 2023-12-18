namespace ShortcutTrainerBackend.Data.TransferObjects;

public class DtoQuestion
{
    public required int Id { get; set; }
    public required string Content { get; set; }
    public required IEnumerable<DtoAnswer> Answers { get; set; }
}