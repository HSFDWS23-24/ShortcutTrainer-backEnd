using System.ComponentModel.DataAnnotations;
using ShortcutTrainerBackend.Data;

namespace ShortcutTrainerBackend.Data.Models;

public class Question
{
    public required int Id { get; set; }
    public required string Content { get; set; }
    public required string Shortcut { get; set; } // ToDo: Format like "strg+c"
    public required QuestionStatus Result { get; set; }
    public required QuestionParameter QuestionParameter { get; set; }
}

public enum QuestionStatus
{
    Unanswered,
    Correct,
    Incorrect
}