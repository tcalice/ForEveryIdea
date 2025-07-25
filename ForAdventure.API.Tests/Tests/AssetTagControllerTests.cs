// Remove the duplicate constructor definition.
// The class should only have one constructor named AssetTagControllerTests.
// If you have another constructor with the same signature elsewhere in this file, remove it.
// Here is the corrected class with a single constructor:

using ForAdventure.API.ForAdventure.Api.Models;
using ForEveryAdventure.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Xunit;

namespace ForEveryAdventure.API.Tests
{
    public class AssetTagControllerTestsBoneyard
    {
        // Clear static store before each test to ensure isolation
        public AssetTagControllerTestsBoneyard()
        {
            //var assetTagsField = typeof(ForAdventure.Api.Controllers.AssetTagController)
            //    .GetField("AssetTags", BindingFlags.Static | BindingFlags.NonPublic);
            //assetTagsField?.SetValue(null, new List<AssetTag>());
            //var assetTagsField = typeof(ForAdventure.Api.Controllers.AssetTagController)
            //    .GetField("AssetTags", BindingFlags.Static | BindingFlags.NonPublic);
            //var store = assetTagsField?.GetValue(null) as List<AssetTag>;
            //store?.Clear();
        }

        // Replace the call to controller.BoneyardTag(userId) with controller.MakeAssetTag(userId)
        // since AssetTagController does not have a BoneyardTag method, but it does have MakeAssetTag.

        [Fact]
        public void MakeAssetTag_ReturnsOkAndAddsTag()
        {
            // Arrange
            var store = new InMemoryAssetTagStore { AssetTags = new List<AssetTag>() };
            var controller = new ForAdventure.Api.Controllers.AssetTagController(store);
            var userId = Guid.NewGuid();

            // Act
            var result = controller.MakeAssetTag(userId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var tag = result.Value as AssetTag;
            Assert.NotNull(tag);
            Assert.Equal(userId, tag.UserId);
            Assert.False(string.IsNullOrWhiteSpace(tag.TagCode));
            Assert.NotEqual(Guid.Empty, tag.Id);

            // Validate tag is added to the in-memory store
            var assetTagsField = typeof(ForAdventure.Api.Controllers.AssetTagController)
                .GetField("AssetTags", BindingFlags.Static | BindingFlags.NonPublic);
            var assetTagsStore = assetTagsField?.GetValue(null) as List<AssetTag>;
            Assert.NotNull(assetTagsStore);
            Assert.Single(assetTagsStore);
            Assert.Equal(tag.Id, assetTagsStore[0].Id);
        }
    }
}