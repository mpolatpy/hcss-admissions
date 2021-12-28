using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public SchoolYear SchoolYear { get; set; }
        public Student Student { get; set; }
        public Guid StudentId { get; set; }
        public string School { get; set; }
        public int Grade { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Notes { get; set; } = null;
        public bool AgreeToTerms { get; set; }
        public string HowDidYouHear { get; set; }
    }
}