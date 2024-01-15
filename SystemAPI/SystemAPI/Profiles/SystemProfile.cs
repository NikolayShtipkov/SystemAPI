using AutoMapper;
using SystemAPI.Models;

namespace SystemAPI.Profiles
{
    public class SystemProfile : Profile
    {
        public SystemProfile()
        {
            CreateMap<Entities.System, SystemDto>().ReverseMap();
        }
    }
}
