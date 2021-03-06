using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace SCLFCrew.Domain
{
    public class AppUser : IdentityUser<int>
    {
        public string SCName { get; set; }
        public string DiscordName { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
