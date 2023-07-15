using TardiscoreAPI.Model;

namespace TardiscoreAPI.Interface
{
    public interface IAuthService
    {
        string GenerateTokenString(LoginUser user);

        Task<bool> Login(LoginUser user);

        Task<(bool, List<string>)> RegisterUser(LoginUser user);
    }
}