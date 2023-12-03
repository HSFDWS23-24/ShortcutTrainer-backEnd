using DevExpress.Xpo;

namespace ShortcutTrainerBackend.Data.Models;

public class Question
{
    public int Id { get; set; }

    // public Course Course { get; set; }
    
    public string Content { get; set; }
    
    public List<Answer> Answers { get; set; }
}