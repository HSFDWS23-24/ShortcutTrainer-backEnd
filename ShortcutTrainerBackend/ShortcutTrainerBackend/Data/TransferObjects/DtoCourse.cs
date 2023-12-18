namespace ShortcutTrainerBackend.Data.TransferObjects;

public class DtoCourse
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Language { get; set; }
    public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string Subscription { get; set; }
    public bool? IsFavorite { get; set; } 
    public required IEnumerable<DtoCourseTag> Tags { get; set; }
    public IEnumerable<DtoQuestion>? Questions { get; set; } //ToDo: ggf. Lazy Load
}