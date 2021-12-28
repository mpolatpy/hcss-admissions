namespace Domain
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Relationship { get; set; }
        public string LastFirst => $"{LastName}, {FirstName}";
        public ICollection<ApplicantParent> Students { get; set; }
    }
}