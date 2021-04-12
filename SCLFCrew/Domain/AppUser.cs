using System;

namespace SCLFCrew.Domain
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string SCName { get; set; }
        public string DiscordName { get; set; }


    }
}
