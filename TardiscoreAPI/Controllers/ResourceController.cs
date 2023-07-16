using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TardiscoreAPI.Helper;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model.Api;

namespace TardiscoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourcesService _resourcesService;

        public ResourceController(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

        /// <summary>
        /// Get the value of a translation key
        /// </summary>
        /// <param name="resourceRequest"></param>
        /// <response code="200">The value of the key</response>
        /// <response code="400">ErrorMessage::"error target"</response>
        [Authorize]
        [HttpPost("key")]
        public IActionResult GetValue(ResourceRequest resourceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var localizedValue = _resourcesService.GetValue(resourceRequest);

            if (string.IsNullOrEmpty(localizedValue))
            {
                var errorMessage = new ResourceRequest()
                {
                    Culture = resourceRequest.Culture,
                    Key = Constants.ErrorMessage.KeyNotFound
                };

                return NotFound(_resourcesService.GetValue(errorMessage));
            }

            return Ok(localizedValue);
        }
    }
}