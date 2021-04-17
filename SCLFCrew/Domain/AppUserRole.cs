using Microsoft.AspNetCore.Identity;

namespace SCLFCrew.Domain
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser AppUser { get; set; }
        public AppRole AppRole { get; set; }
    }
}