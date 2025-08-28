using AutoMapper;
using SignalR_Project.Application.DTOs;
using SignalR_Project.Application.VMs;
using SignalR_Project.Core.Entities;

namespace SignalR_Project.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, AppUserCreateDTO>().ReverseMap();
            CreateMap<AppUser, RegisterVM>().ReverseMap();
        }
    }
}
