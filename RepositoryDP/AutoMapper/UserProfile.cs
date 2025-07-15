using AutoMapper;
using RepositoryDP.DTO.UserDTO;
using RepositoryDP.Model;

namespace RepositoryDP.AutoMapper
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<User,AddUserAddressDTO>().ReverseMap();
            CreateMap<User,UpdateUserAddressDTO>().ReverseMap();
            CreateMap<User,GetUserAddressDTO>().ReverseMap();
        }
    }
}
