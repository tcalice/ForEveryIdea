using ForEveryAdventure.Api.Models;

namespace ForAdventure.API.ForAdventure.Api.Models
{
    public interface IAssetTagStore
    {
        List<AssetTag> AssetTags { get; }
    }

    public class AssetTagStore : IAssetTagStore
    {
        public List<AssetTag> AssetTags { get; } = new List<AssetTag>();
    }
}
