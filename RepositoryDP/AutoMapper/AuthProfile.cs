using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RepositoryDP.DTO.AuthDTO;
using RepositoryDP.Model;

namespace RepositoryDP.AutoMapper
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<MyUserModel, RegisterUserDTO>().ReverseMap();
            CreateMap<MyUserModel, LoginUserDTO>().ReverseMap();
            CreateMap<MyUserModel, UserResponseDTO>().ReverseMap();
        }
    }
}
