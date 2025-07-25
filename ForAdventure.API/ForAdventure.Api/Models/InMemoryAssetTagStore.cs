using ForEveryAdventure.Api.Models;

namespace ForAdventure.API.ForAdventure.Api.Models
{
    public class InMemoryAssetTagStore : IAssetTagStore
    {
        public required List<AssetTag> AssetTags { get; set; }
    }
}
