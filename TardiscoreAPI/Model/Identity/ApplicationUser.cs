using Microsoft.AspNetCore.Identity;

namespace TardiscoreAPI.Model.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string PreferredLanguage { get; init; } = "en-EN";
    }
}