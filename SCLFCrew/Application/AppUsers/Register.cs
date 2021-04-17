using System.Threading;
using System.Threading.Tasks;
using MediatR;
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
            private readonly DataContext _context;
            private ITokenService _tokenService { get; }
            public Handler(DataContext context, ITokenService tokenService)
            {
                _tokenService = tokenService;
                _context = context;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            { 
                var user = new AppUser()
                {
                    UserName = request.RegisterDto.Username.ToLower(),
                    SCName = request.RegisterDto.SCName,
                    DiscordName = request.RegisterDto.DiscordName
                };
                _context.AppUsers.Add(user);
                await _context.SaveChangesAsync();
                return new UserDto() 
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }


        }
    }
}