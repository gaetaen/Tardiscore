using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using TardiscoreAPI.Helper;

namespace TardiscoreAPI.Model
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$", ErrorMessage = Constants.ErrorMessage.InvalidEmail)]
        public required string Email { get; init; }

        [Required(ErrorMessage = "UserName is required.")]
        public required string UserName { get; init; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; init; }
    }
}