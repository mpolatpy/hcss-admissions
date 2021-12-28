namespace Domain
{
    public class ApplicantParent
    {
        public Student Student { get; set; }
        public Guid StudentId { get; set; }
        public Parent Parent { get; set; }
        public int ParentId { get; set; }
        public bool IsPrimaryParent { get; set; } = false;

    }
}