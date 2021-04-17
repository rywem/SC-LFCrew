using System.ComponentModel.DataAnnotations;

namespace SCLFCrew.Domain.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string SCName { get; set; }
        public string DiscordName { get; set; }
    }
}