using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SCLFCrew.Application.Interfaces;
using SCLFCrew.Domain;
using SCLFCrew.Domain.DTOs;
using SCLFCrew.Persistence;

namespace SCLFCrew.Application.AppUsers
{
public class Register
    {
        public class Command : IRequest<UserDto>
        {
            public RegisterDto RegisterDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, UserDto>
        {
            private ITokenService _tokenService { get; }
            private UserManager<AppUser> _userManager;
             private readonly IMapper _mapper;
            private SignInManager<AppUser> _signInManager;
            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
            {
                _tokenService = tokenService;
                _mapper = mapper;
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            { 
                var user = _mapper.Map<AppUser>(request.RegisterDto);
                user.UserName = request.RegisterDto.Username.ToLower();
                
                var result = await _userManager.CreateAsync(user, request.RegisterDto.Password);
                
                if ( !result.Succeeded )
                    return null;
                
                return new UserDto() 
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }
        }
    }
}