using TardiscoreAPI.Model.Api;

namespace TardiscoreAPI.Interface
{
    public interface IAuthService
    {
        Task<bool> Login(LoginUserRequest user);

        Task<(bool, List<string>)> RegisterUser(LoginUserRequest user);

        RefreshToken GenerateRefreshToken();

        Task<string> GenerateTokenString(LoginUserRequest user);

        Task SetRefreshToken(RefreshToken newRefreshToken, string userMail);
    }
}