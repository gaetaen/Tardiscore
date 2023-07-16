using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using TardiscoreAPI.Helper;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model.Api;

namespace TardiscoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Register a user
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">SuccessMessage::RegisterSucceeded</response>
        /// <response code="400">ErrorMessage::"error target"</response>
        [HttpPost("Register")]
        public async Task<ActionResult<string>> RegisterUser([FromBody] LoginUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            (bool registrationSuccess, List<string> errorMessages) = await _authService.RegisterUser(user);

            if (registrationSuccess) return Ok(Constants.SuccessMessage.RegisterSucceeded);

            return BadRequest(errorMessages);
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="user"></param>
        /// <response code="200">JWT token</response>
        /// <response code="400">ErrorMessage::"error target"</response>
        [HttpPost("Login")]
        public async Task<ActionResult<Jwt>> Login([FromBody] LoginUserRequest user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool loginSuccess = await _authService.Login(user);
            if (loginSuccess)
            {
                var token = new Jwt()
                {
                    Token = await _authService.GenerateTokenString(user)
                };

                return Ok(token);
            }

            return Unauthorized(Constants.ErrorMessage.InvalidCredentials);
        }
    }
}