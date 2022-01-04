using System.Text.Json.Serialization;

namespace Domain
{
    public class SchoolYear
    {
        public int Id { get; set; }
        public bool IsActiveYear { get; set; }
        public string SchoolYearName { get; set; }
        public string FormLabel { get; set; }
        public bool DisplayOnForm { get; set; }
        [JsonIgnore]
        public ICollection<Application> Applications { get; set; }
        [JsonIgnore]
        public ICollection<Lottery> Lotteries { get; set; } = new List<Lottery>();
    }
}