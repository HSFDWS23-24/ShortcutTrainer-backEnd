using System.ComponentModel.DataAnnotations;

namespace ShortcutTrainerBackend.Data.Models;

public class Question
{
    public required int Id { get; set; }
    public required string Content { get; set; }
    public required string Shortcut { get; set; } // ToDo: Format like "strg+c"
}