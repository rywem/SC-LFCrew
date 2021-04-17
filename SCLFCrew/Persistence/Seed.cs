using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SCLFCrew.Domain;

namespace SCLFCrew.Persistence
{
    public class Seed
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync()) 
                return;

            var roles = new List<AppRole>()
            {
                new AppRole{ Name = "Member" },
                new AppRole{ Name = "Support" },
                new AppRole{ Name = "Admin"}
            };

            foreach(var role in roles) 
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new AppUser
            {
                Id = 1,
                UserName = "admin",
                SCName = "admin",
                DiscordName = "admin#0001",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            await userManager.CreateAsync(admin, "Password1");

            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Support" });
        }
    }
}