namespace Domain
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string LastFirst => $"{LastName}, {FirstName}";
        public string Gender { get; set; }
        public ICollection<ApplicantParent> Parents { get; set; }
        public string CurrentSchool { get; set; }
        public int CurrentGrade { get; set; }
        public bool HasSibling { get; set; } = false;
        public string SiblingName { get; set; } = null;
        public DateTime DOB { get; set; }
        public string LotteryStatus { get; set; } = "Initial  Application";
        public int WaitlistNumber { get; set; } = -1;
    }
}