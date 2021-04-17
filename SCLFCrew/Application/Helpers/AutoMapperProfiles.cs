using System.Linq;
using SCLFCrew.Domain.DTOs;
using AutoMapper;
using SCLFCrew.Domain;

namespace SCLFCrew.Application.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
        }
    }
}