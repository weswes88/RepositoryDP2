using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryDP.DTO.RolesDTO;

namespace RepositoryDP.Service.Roles
{
    public class RolseService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        public RolseService(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<RoleDTO> CreateRole (RoleDTO roleDTO)
        {
            var existingRole = await _roleManager.FindByNameAsync(roleDTO.Name.ToUpper());
            if (existingRole != null)
            {
                throw new Exception("Role Name already exists");
            }
            
            var newRole =_mapper.Map<IdentityRole>(roleDTO);
            var res = await _roleManager.CreateAsync(newRole);
            if (!res.Succeeded)
            {
                throw new Exception($"Failed to create Role: {res.Errors}");
            }

            var respose = _mapper.Map<RoleDTO>(newRole);
            return respose;
        }

        public async Task <List<RoleDTO>> GetRoles()
        {
            var res = await _roleManager.Roles.ToListAsync();
            var response = _mapper.Map<List<RoleDTO>>(res);
            return response; 
        }

        public async Task<RoleDTO> UpdateRoleByName(UpdateRoleDTO roleDTO)
        {
            //var existingRole = await _roleManager.FindByNameAsync(roleDTO.Name.ToUpper());
            //if (existingRole == null)
            //{
            //    throw new Exception("Role Name Doesnt exists");
            //}

            var newRole = _mapper.Map<IdentityRole>(roleDTO);
            var res = await _roleManager.UpdateAsync(newRole);
            if (!res.Succeeded)
            {
                throw new Exception($"Failed to update Role: {res.Errors}");
            }
            var response = _mapper.Map<RoleDTO>(newRole);
            return response;
        }

        public async Task<string> DeleteRole(RoleDTO roleDTO)
        {
            var existingRole = await _roleManager.FindByNameAsync(roleDTO.Name);
            if (existingRole == null)
            {
                throw new Exception("Role Name Doesnt exists");
            }

            //var newRole = _mapper.Map<IdentityRole>(roleDTO);
            var res = await _roleManager.DeleteAsync(existingRole);
            if (!res.Succeeded)
            {
                throw new Exception($"Failed to Delete Role: {res.Errors}");
            }
            return "Role Deleted Successfuly";
        }
    }
}
