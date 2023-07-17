namespace TardiscoreAPI.Model.Api
{
    public class RefreshToken
    {
        public required string Token { get; init; }
        public required DateTime Created { get; init; }
        public required DateTime Expires { get; init; }
    }
}