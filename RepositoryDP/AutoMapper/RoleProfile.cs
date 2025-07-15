using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RepositoryDP.DTO.RolesDTO;

namespace RepositoryDP.AutoMapper
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleDTO>().ReverseMap();
            CreateMap<IdentityRole, UpdateRoleDTO>().ReverseMap();
        }
    }
}
