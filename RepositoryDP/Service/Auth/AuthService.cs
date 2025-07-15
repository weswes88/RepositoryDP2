using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using RepositoryDP.DTO.AuthDTO;
using RepositoryDP.Model;
using System.Security.Cryptography;
using System.Text;

namespace RepositoryDP.Service.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<MyUserModel> _userManager;
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        public AuthService(UserManager<MyUserModel> userManager, IMapper mapper, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task <UserResponseDTO> RegisterUserAsync (RegisterUserDTO registerUser)
        {
            //1 - ensure the user is not exist before

            var existingUser = await _userManager.FindByEmailAsync(registerUser.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }
            //------------------------------------------------------------------------
            var newUser = _mapper.Map<MyUserModel>(registerUser);

            // Generate a unique username
            newUser.UserName = "NotDefined";

            var result = await _userManager.CreateAsync(newUser, registerUser.Password); // registered
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create user: {result.Errors}");
            }

            // add Role
            var role = await _userManager.AddToRoleAsync(newUser, registerUser.Role);
            // Generate Token
            var token = await _tokenService.GenerateToken(newUser);

            var response = _mapper.Map<UserResponseDTO>(newUser);
            //response.Token = token;
            //response.Role=registerUser.Role;

            return response;
        }

        public async Task<UserResponseDTO> LoginUserAsync (LoginUserDTO loginUser)
        {
            if (loginUser == null)
            {
                throw new ArgumentNullException(nameof(loginUser));
            }

            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginUser.Password))
            {
                throw new Exception("Invalid email or password");
            }

            // Generate access token
            var token = await _tokenService.GenerateToken(user); // gernerate token

            // Generate refresh token
            var refreshToken = _tokenService.GenerateRefreshToken();

            // Hash the refresh token and store it in the database or override the existing refresh token
            using var sha256 = SHA256.Create();
            var refreshTokenHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(refreshToken));
            user.RefreshToken = Convert.ToBase64String(refreshTokenHash);
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(2);

            // Update user information in database
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to update user: {result.Errors}");
            }

            var userResponse = _mapper.Map<UserResponseDTO>(user);
            userResponse.Token = token;

            return userResponse;
        }
        //public async Task<RoleDTO> AddRole (RoleDTO roleDTO)
        //{
        //    var existingRole = await _userManager.IsInRoleAsync();
        //    if (existingRole != null)
        //    {
        //        throw new Exception("");
        //    }
        //}
    }
}
