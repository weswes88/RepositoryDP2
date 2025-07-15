using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RepositoryDP.DTO.UserDTO;
using RepositoryDP.Service.UserService;

namespace RepositoryDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("AddUserAddress")]
        public async Task<IActionResult> AddUserAddress([FromBody] AddUserAddressDTO DTO)
        {
            var user =await _userService.AddUser(DTO);
            return Ok(user);
        }

        [HttpGet("GetUserAddress")]
        public async Task<IActionResult> GetUserAddress()
        {
            var res =await _userService.GetUsers();
            return Ok(res);
        }

        [HttpGet("GetUserAddressById")]
        public async Task<IActionResult> GetUserAddressById([FromQuery] int id)
        {
            var res =await _userService.GetById(id);
            return Ok(res);
        }
        
        [HttpPut("UpdateUserAddress")]
        public async Task<IActionResult> UpdateUserAddress(UpdateUserAddressDTO DTO)
        {
            var res =await _userService.UpdateUser(DTO);
            return Ok(res);
        }

        [HttpDelete("DeleteUserAddress/{id}")]
        public async Task<IActionResult> DeleteUserAddress([FromRoute] int id)
        {
            await _userService.DeleteUser(id);
            return Ok("Deleted");
        }

    }
}
