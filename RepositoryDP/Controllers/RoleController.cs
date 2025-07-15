using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDP.DTO.RolesDTO;
using RepositoryDP.Service.Roles;

namespace RepositoryDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole (RoleDTO roleDTO)
        {
            try
            {
                var res = await _roleService.CreateRole(roleDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("GetRoles")]
        public async Task <IActionResult> GetRoles ()
        {
            try
            {
                var res =await _roleService.GetRoles();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole (UpdateRoleDTO roleDTO)
        {
            try
            {
                var res = await _roleService.UpdateRoleByName(roleDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult>DeleteRole(RoleDTO roleDTO)
        {
            try
            {
                var res = await _roleService.DeleteRole(roleDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
