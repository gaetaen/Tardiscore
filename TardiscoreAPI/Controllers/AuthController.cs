using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TardiscoreAPI.Helper;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model;

namespace TardiscoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            (bool registrationSuccess, List<string> errorMessages) = await _authService.RegisterUser(user);

            if (registrationSuccess) return Ok(Constants.SuccessMessage.RegisterSucceeded);

            return BadRequest(errorMessages);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool loginSuccess = await _authService.Login(user);
            if (loginSuccess)
            {
                var tokenString = _authService.GenerateTokenString(user);
                return Ok(tokenString);
            }

            return Unauthorized(Constants.ErrorMessage.InvalidCredentials);
        }
    }
}