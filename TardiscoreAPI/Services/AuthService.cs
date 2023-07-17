using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TardiscoreAPI.Helper;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model.Api;
using TardiscoreAPI.Model.Identity;

namespace TardiscoreAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<(bool, List<string>)> RegisterUser(LoginUserRequest user)
        {
            var errorMessages = new List<string>();

            var usernameExists = await _userManager.FindByNameAsync(user.UserName);
            var emailExists = await _userManager.FindByEmailAsync(user.Email);

            if (usernameExists is not null)
            {
                errorMessages.Add(Constants.ErrorMessage.UserNameExist);
                return (false, errorMessages);
            }

            if (emailExists is not null)
            {
                errorMessages.Add(Constants.ErrorMessage.EmailExist);
                return (false, errorMessages);
            }

            var identityUser = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            var newUser = await _userManager.FindByEmailAsync(user.Email);

            if (!result.Succeeded || newUser is null)
            {
                Dictionary<string, string> constantMap = new()
                {
                    { "PasswordRequiresDigit", Constants.ErrorMessage.PasswordRequiresDigit },
                    { "PasswordRequiresUpper", Constants.ErrorMessage.PasswordRequiresUpper },
                    { "PasswordRequiresLower", Constants.ErrorMessage.PasswordRequiresLower },
                    { "PasswordTooShort", Constants.ErrorMessage.PasswordTooShort },
                    { "InvalidEmail", Constants.ErrorMessage.InvalidEmail },
                };

                if (!result.Errors.Any()) return (false, errorMessages);

                var list = result.Errors.Select(x =>
                {
                    if (constantMap.TryGetValue(x.Code, out string? value))
                        return value;
                    else
                        return x.Code;
                }).ToList();

                errorMessages.AddRange(list);

                return (false, errorMessages);
            }

            await _userManager.AddToRoleAsync(newUser, "User");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "User"),
            };

            await _userManager.AddClaimsAsync(identityUser, claims);
            return (true, errorMessages);
        }

        public async Task<bool> Login(LoginUserRequest user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public async Task<string> GenerateTokenString(LoginUserRequest user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser is null)
            {
                return string.Empty;
            }

            var claims = await _userManager.GetClaimsAsync(identityUser);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);
            var expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpiresInMinutes"]));

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken()
        {
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Created = DateTime.Now,
                Expires = DateTime.Now.AddDays(7)
            };
        }

        public async Task SetRefreshToken(RefreshToken newRefreshToken, string userMail)
        {
            var user = await _userManager.FindByEmailAsync(userMail);

            if (user == null) { return; }

            user.RefreshToken = newRefreshToken.Token;
            user.RefreshTokenCreation = newRefreshToken.Created;
            user.RefreshTokenExpiration = newRefreshToken.Expires;

            await _userManager.UpdateAsync(user);
        }
    }
}