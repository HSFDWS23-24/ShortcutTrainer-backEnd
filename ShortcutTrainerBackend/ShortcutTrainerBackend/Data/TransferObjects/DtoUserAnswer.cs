namespace ShortcutTrainerBackend.Data.TransferObjects;

public class DtoUserAnswer
{
    public required DtoUser User  { get; set; }
    public required DtoAnswer Answer { get; set; }
    public required string QuestionStatus { get; set; }
}