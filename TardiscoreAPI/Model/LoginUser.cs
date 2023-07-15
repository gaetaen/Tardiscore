using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TardiscoreAPI.Model
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Email is required.")]
        public required string Email { get; init; }

        [Required(ErrorMessage = "UserName is required.")]
        public required string UserName { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; init; }
    }
}