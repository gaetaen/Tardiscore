using System.ComponentModel.DataAnnotations;

namespace TardiscoreAPI.Model.Api
{
    public class ResourceRequest
    {
        [Required]
        public required string Key { get; set; }

        [Required]//[AllowedValues("fr-FR", "en-EN")] .net 8
        [RegularExpression("fr-FR|en-EN", ErrorMessage = "Culture must be either 'fr-FR' or 'en-EN'.")]
        public required string Culture { get; set; }
    }
}
