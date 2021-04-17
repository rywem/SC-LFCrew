using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCLFCrew.Application.AppUsers;
using SCLFCrew.Domain;
using SCLFCrew.Domain.DTOs;
using SCLFCrew.Persistence;

namespace SCLFCrew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;           
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.Username))
                return BadRequest("Username is taken.");
            
            var result = await Mediator.Send(new Register.Command(){ RegisterDto = registerDto });

            if ( result == null )
                return BadRequest("Invalid");

            return result;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var result = await Mediator.Send(new Login.Command() { LoginDto = loginDto });

            if ( result == null )
                return Unauthorized("Invalid");
            else 
                return result;
        }
    }
}