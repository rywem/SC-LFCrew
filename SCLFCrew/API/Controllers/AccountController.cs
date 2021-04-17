using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCLFCrew.Application.AppUsers;
using SCLFCrew.Domain.DTOs;
using SCLFCrew.Persistence;

namespace SCLFCrew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;            
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.Username))
                return BadRequest("Username is taken.");
            
            return await Mediator.Send(new Register.Command(){ RegisterDto = registerDto });                      
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.AppUsers.AnyAsync(x => x.UserName == username.ToLower());
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