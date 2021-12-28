using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Students
{
    public class StudentDto
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime DOB { get; set; }
        public string PrimaryParent { get; set; }
        public string SecondaryParent { get; set; }
    }
}