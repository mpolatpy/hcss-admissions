using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public ICollection<Application> Applications { get; set; }
        public ICollection<IdentityUserRole<string>> UserRoles { get; set; }
    }
}