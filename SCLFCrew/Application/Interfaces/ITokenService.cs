using System.Threading.Tasks;
using SCLFCrew.Domain;

namespace SCLFCrew.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}