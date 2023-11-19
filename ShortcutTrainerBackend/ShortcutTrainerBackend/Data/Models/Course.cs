namespace ShortcutTrainerBackend.Data.Models;

    public class Course
    {
    public required int Id { get; set; }
    public required string Title { get; set; }
        public required string Description { get; set; }
    public required string ImageUrl { get; set; }
    public required string PaymentType { get; set; }
    public required Category Category { get; set; } // ToDo: FK on Categories(Id)
    public required int Progress { get; set; } // ToDo: where to save progress? calc can be done in service layer
    public required List<Question> Questions { get; set; } // ToDo: Questions have FK on Course(Id) -> 1:N-Association in DevExpress XPO
}
