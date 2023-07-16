using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TardiscoreAPI.Helper;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model;
using TardiscoreAPI.Model.Api;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TardiscoreAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<(bool, List<string>)> RegisterUser(LoginUser user)
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

            var identityUser = new IdentityUser
            {
                UserName = user.UserName,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            if (!result.Succeeded)
            {
                Dictionary<string, string> constantMap = new Dictionary<string, string>
                {
                    { "PasswordRequiresDigit", Constants.ErrorMessage.PasswordRequiresDigit },
                    { "PasswordRequiresUpper", Constants.ErrorMessage.PasswordRequiresUpper },
                    { "PasswordRequiresLower", Constants.ErrorMessage.PasswordRequiresLower },
                    { "PasswordTooShort", Constants.ErrorMessage.PasswordTooShort },
                    { "InvalidEmail", Constants.ErrorMessage.InvalidEmail },
                };

                if (result.Errors.Any())
                {
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

                return (false, errorMessages);
            }

            return (true, errorMessages);
        }

        public async Task<bool> Login(LoginUser user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Email);
            if (identityUser is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(identityUser, user.Password);
        }

        public string GenerateTokenString(LoginUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
            };

            var key = _config["Jwt:Key"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? throw new InvalidOperationException("JWT key is not configured")));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
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
    }
}