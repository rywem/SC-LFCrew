using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SCLFCrew.Application.Interfaces;
using SCLFCrew.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SCLFCrew.Persistence;
using Microsoft.AspNetCore.Identity;
using SCLFCrew.Domain;

namespace SCLFCrew.Application.AppUsers
{
    public class Login
    {
        public class Command : IRequest<UserDto>
        {
            public LoginDto LoginDto { get; set; }
            
        }
        
        public class Handler : IRequestHandler<Command, UserDto>
        {
            private ITokenService _tokenService;
            private UserManager<AppUser> _userManager;
            private SignInManager<AppUser> _signInManager;
            public Handler (UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
            {
                _tokenService = tokenService;
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            {                           
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == request.LoginDto.Username.ToLower());

                if ( user == null )
                    return null;

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.LoginDto.Password, false);

                if ( !result.Succeeded )
                    return null;

                return new UserDto() 
                {
                    Username = user.UserName,
                    Token = await _tokenService.CreateToken(user)
                };
            }
        }
    }
}