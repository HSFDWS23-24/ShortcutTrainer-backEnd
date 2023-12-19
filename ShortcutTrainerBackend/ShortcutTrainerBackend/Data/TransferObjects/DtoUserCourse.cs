namespace ShortcutTrainerBackend.Data.TransferObjects;

public class DtoUserCourse
{
    public required DtoUser User  { get; set; }
    public required DtoCourse Course { get; set; }
    public required bool Favorite { get; set; }
}