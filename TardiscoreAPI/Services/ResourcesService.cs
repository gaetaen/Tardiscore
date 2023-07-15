using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Resources;
using TardiscoreAPI.Interface;
using TardiscoreAPI.Model.Api;
using TardiscoreAPI.Properties;

namespace TardiscoreAPI.Services
{
    public class ResourcesService : IResourcesService
    {
        public string GetValue(ResourceRequest resourceRequest)
        {
            var culture = Resources.Culture = new CultureInfo(resourceRequest.Culture);

            var localizedValue = Resources.ResourceManager.GetString(resourceRequest.Key, culture);

            if (string.IsNullOrEmpty(localizedValue))
            {
                return string.Empty;
            }

            return localizedValue;
        }
    }
}