using AutoMapper;
using CarParts.Domain.Entities;
using CarsParts.Application.Dto;

namespace CarsParts.Application.Mapping
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            this.CreateMap<AppUser, AppUserDto>().ReverseMap();


        }
    }
}
