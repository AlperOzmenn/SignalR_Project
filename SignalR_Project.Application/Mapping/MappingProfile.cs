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
            // AppUser Mapping
            //CreateMap<AppUser, AppUserCreateDTO>().ReverseMap();
            CreateMap<AppUser, RegisterVM>().ReverseMap();
            CreateMap<AppUser, LoginVM>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();

        }
    }
}
