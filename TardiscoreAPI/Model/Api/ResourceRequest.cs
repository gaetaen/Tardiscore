using System.ComponentModel.DataAnnotations;

namespace TardiscoreAPI.Model.Api
{
    public class ResourceRequest
    {
        /// <summary>
        /// The name of the key
        /// </summary>
        /// <example>SuccessMessage::Default</example>
        [Required]
        public required string Key { get; init; }

        /// <summary>
        /// The language code
        /// </summary>
        /// <example>en-EN</example>
        [Required]//[AllowedValues("fr-FR", "en-EN")] .net 8
        [RegularExpression("fr-FR|en-EN", ErrorMessage = "Culture must be either 'fr-FR' or 'en-EN'.")]
        public required string Culture { get; init; }
    }
}