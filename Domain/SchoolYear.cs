namespace Domain
{
    public class SchoolYear
    {
        public int SchoolYearId { get; set; }
        public bool IsActiveYear { get; set; }
        public string Name { get; set; }
        public bool DisplayOnForm { get; set; }
        public ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}