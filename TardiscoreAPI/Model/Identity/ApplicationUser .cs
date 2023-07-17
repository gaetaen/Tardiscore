using Microsoft.AspNetCore.Identity;

namespace TardiscoreAPI.Model.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string PreferredLanguage { get; init; } = "en-EN";
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenCreation { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}