using Microsoft.AspNetCore.Identity;
using RepositoryDP.Model;

namespace RepositoryDP.Service.Auth
{
    public interface ITokenService
    {
        Task<string> GenerateToken(MyUserModel user);
        string GenerateRefreshToken();
    }
}
