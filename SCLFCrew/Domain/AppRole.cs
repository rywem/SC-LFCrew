using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SCLFCrew.Domain
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}