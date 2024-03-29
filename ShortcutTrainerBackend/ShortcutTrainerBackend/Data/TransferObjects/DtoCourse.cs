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
    public required int AnsweredCorrect { get; set; }
    public required int AnsweredIncorrect { get; set; }
    public required int AmountQuestions { get; set; }



}