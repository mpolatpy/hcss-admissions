namespace Application.Applications
{
    public class ApplicationDto
    {
        public Guid Id { get; set; }
        public int SchoolYearId { get; set; }
        public int LotteryId { get; set; }
        public int SchoolId { get; set; }
        public int Grade { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } = null;
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PrimaryParentName { get; set; }
        public string PrimaryParentEmail { get; set; }
        public string PrimaryParentPhoneNumber { get; set; }
        public string PrimaryParentRelationship { get; set; }
        public string SecondaryParentName { get; set; } = null;
        public string SecondaryParentEmail { get; set; } = null;
        public string SecondaryParentPhoneNumber { get; set; } = null;
        public string SecondaryParentRelationship { get; set; } = null;
        public string CurrentSchool { get; set; }
        public string CurrentGrade { get; set; }
        public bool HasSibling { get; set; } = false;
        public string SiblingName { get; set; } = null;
        public bool AgreeToTerms { get; set; }
        public string HowDidYouHear { get; set; }
    }
}