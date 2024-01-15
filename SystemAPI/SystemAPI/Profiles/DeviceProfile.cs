using AutoMapper;
using SystemAPI.Entities;
using SystemAPI.Models;

namespace SystemAPI.Profiles
{
    public class DeviceProfile : Profile
    {
        public DeviceProfile()
        {
            CreateMap<Device, DeviceDto>().ReverseMap();
        }
    }
}
