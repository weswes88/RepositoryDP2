using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryDP.DTO.AuthDTO;
using RepositoryDP.Service.Auth;

namespace RepositoryDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register (RegisterUserDTO registerUserDTO)
        {
            try
            {
                var res = await _authService.RegisterUserAsync(registerUserDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> login(LoginUserDTO loginUserDTO)
        {
            try
            {
                var res = await _authService.LoginUserAsync(loginUserDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
