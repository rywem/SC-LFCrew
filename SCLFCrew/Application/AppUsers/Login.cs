using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SCLFCrew.Application.Interfaces;
using SCLFCrew.Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SCLFCrew.Persistence;
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
            private readonly DataContext _context;
            private ITokenService _tokenService;
            public Handler (DataContext context, ITokenService tokenService)
            {
                _context = context;
                _tokenService = tokenService;
            }

            public async Task<UserDto> Handle(Command request, CancellationToken cancellationToken)
            {                              
                var user = await _context.AppUsers.SingleOrDefaultAsync(x => x.UserName == request.LoginDto.Username);

                if ( user == null )
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