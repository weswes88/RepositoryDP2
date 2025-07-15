using RepositoryDP.DTO.AuthDTO;

namespace RepositoryDP.Service.Auth
{
    public interface IAuthService
    {
         Task<UserResponseDTO> RegisterUserAsync(RegisterUserDTO registerUser);
         Task<UserResponseDTO> LoginUserAsync(LoginUserDTO loginUser);

    }
}
