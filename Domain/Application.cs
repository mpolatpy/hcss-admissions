using System.Text.Json.Serialization;

namespace Domain
{
    public class Application
    {
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public string Notes { get; set; } = null;
        public bool AgreeToTerms { get; set; }
        public string HowDidYouHear { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int SchoolYearId { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}