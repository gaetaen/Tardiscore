using TardiscoreAPI.Model.Api;

namespace TardiscoreAPI.Interface
{
    public interface IResourcesService
    {
        string GetValue(ResourceRequest resourceRequest);
    }
}