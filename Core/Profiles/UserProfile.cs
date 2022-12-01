using AutoMapper;
using Core.Entities;
using UpdateUserDTO = Core.DTO.UserDTO.UpdateUserDTO;
using UserDTO = Core.DTO.UserDTO.UserDTO;
using UserRegistrationDTO = Core.DTO.UserDTO.UserRegistrationDTO;

namespace Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRegistrationDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UpdateUserDTO>().ReverseMap();
        }

    }
}