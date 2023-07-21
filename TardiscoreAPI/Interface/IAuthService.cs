using TardiscoreAPI.Model.Api;

namespace TardiscoreAPI.Interface
{
    public interface IAuthService
    {
        Task<bool> Login(LoginUserRequest user);

        Task<(bool, List<string>)> RegisterUser(LoginUserRequest user);

        RefreshToken GenerateRefreshToken();

        Task<string> GenerateAccessToken(string userEmail);

        Task SetRefreshToken(RefreshToken newRefreshToken, string userMail);

        Task<(bool, string)> CheckRefreshToken(string refreshToken);
    }
}