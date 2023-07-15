using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model.Api;
using TardiscoreAPI.Properties;

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

        [HttpPost("key")]
        public IActionResult GetValue(ResourceRequest resourceRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Resources.Culture = new CultureInfo(resourceRequest.Culture);

            var localizedValue = _resourcesService.GetValue(resourceRequest);

            if (string.IsNullOrEmpty(localizedValue))
            {
                return NotFound("Key not found");
            }

            return Ok(localizedValue);
        }
    }
}