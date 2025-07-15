using RepositoryDP.DTO.RolesDTO;

namespace RepositoryDP.Service.Roles
{
    public interface IRoleService
    {
        Task<RoleDTO> CreateRole(RoleDTO roleDTO);
        Task<List<RoleDTO>> GetRoles();
        Task<RoleDTO> UpdateRoleByName(UpdateRoleDTO roleDTO);
        Task<string> DeleteRole(RoleDTO roleDTO);
    }
}
