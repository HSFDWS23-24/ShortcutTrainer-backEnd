namespace ShortcutTrainerBackend.Data.Models
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public SubscriptionType Subscription { get; set; }
        public List<CourseTag> Tags { get; set; }
        public bool? IsFavorite { get; set; }  
        public int? AnsweredCorrect { get; set; }
        public int? AnsweredIncorrect { get; set; }
        public int AmountQuestions { get; set; }

    }

}
