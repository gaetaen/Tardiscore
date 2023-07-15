using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TardiscoreAPI.Helper;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model.Api;

namespace TardiscoreAPI.Controllers
{
    [Route("api/a[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourcesService _resourcesService;

        public ResourceController(IResourcesService resourcesService)
        {
            _resourcesService = resourcesService;
        }

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