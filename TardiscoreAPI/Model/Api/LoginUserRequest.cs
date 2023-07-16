using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using TardiscoreAPI.Helper;

namespace TardiscoreAPI.Model.Api
{
    public class LoginUserRequest
    {
        /// <summary>
        /// The email of the user
        /// </summary>
        /// <example>gaetaenP@hotmail.com</example>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = Constants.ErrorMessage.InvalidEmail)]
        public required string Email { get; init; }

        /// <summary>
        /// The name of the user
        /// </summary>
        /// <example>GaetaenP</example>
        [Required(ErrorMessage = "UserName is required.")]
        public required string UserName { get; init; }

        /// <summary>
        /// The Password of the user
        /// </summary>
        /// <example>Azerty0</example>
        [Required(ErrorMessage = "Password is required.")]
        [PasswordPropertyText]
        public required string Password { get; init; }
    }
}