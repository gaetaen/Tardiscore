using TardiscoreAPI.Model.Api;

namespace TardiscoreAPI.Interface
{
    public interface IAuthService
    {
        Task<string> GenerateTokenString(LoginUserRequest user);

        Task<bool> Login(LoginUserRequest user);

        Task<(bool, List<string>)> RegisterUser(LoginUserRequest user);
    }
}