namespace TardiscoreAPI.Model.Api
{
    public class Jwt
    {
        /// <summary>
        /// The JWT token of the user
        /// </summary>
        /// <example>eyJhbGciOiJIUzUxMiJ9.eyJSb2xlIjoidHQiLCJJc3N1ZXIiOiJJc3N1ZXIiLCJVc2VybmFtZSI6IkphdmFJblVzZSIsImV4cCI6MTY4OTUzNjY5NiwiaWF0IjoxNjg5NTM2Njk2fQ.Bpipj5IyahKnDazA8F4Il0zsghKVrnbBuYJxKTTckclyUCRTJ5f0J6krFA0vyOoKTJmLbosPlC8q_PtKaNSeDA</example>
        public required string Token { get; init; }
    }
}