using Microsoft.AspNetCore.Identity;

namespace RepositoryDP.Model
{
    public class MyUserModel :IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
