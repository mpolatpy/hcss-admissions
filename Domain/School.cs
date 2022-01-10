using System.Text.Json.Serialization;

namespace Domain
{
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        [JsonIgnore]
        public ICollection<Application> Applications { get; set; }
        [JsonIgnore]
        public ICollection<WaitList> WaitLists { get; set; }
    }
}