using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class Answer
{
    public int Id { get; set; }

    public Question Question { get; set; }

    public string System { get; set; }

    public string Shortcut { get; set; }
}