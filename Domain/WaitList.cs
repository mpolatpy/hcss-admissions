namespace Domain
{
    public class WaitList
    {
        public int Id { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public int SchoolYearId { get; set; }
        public int Grade { get; set; }
        public School School { get; set; }
        public int SchoolID { get; set; }
        public ICollection<StudentWaitLists> Students { get; set; } = new List<StudentWaitLists>();
    }
}