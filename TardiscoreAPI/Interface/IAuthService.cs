using TardiscoreAPI.Model;

namespace TardiscoreAPI.Interface
{
    public interface IAuthService
    {
        string GenerateTokenString(LoginUser user);

        Task<bool> Login(LoginUser user);

        Task<(bool, string)> RegisterUser(LoginUser user);
    }
}