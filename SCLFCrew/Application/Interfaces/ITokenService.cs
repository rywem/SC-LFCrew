using SCLFCrew.Domain;

namespace SCLFCrew.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}