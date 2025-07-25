using ForAdventure.Api.Controllers;
using ForAdventure.API.ForAdventure.Api.Models;
using ForEveryAdventure.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace ForEveryAdventure.API.Tests
{
    public class AssetTagControllerTests
    {
        // Clear static store before each test to ensure isolation
        public AssetTagControllerTests()
        {
            //var assetTagsField = typeof(AssetTagController)
            //    .GetField("AssetTags", BindingFlags.Static | BindingFlags.NonPublic);
            //

            /*  2025-07-24 https://foreveryidea.sharepoint.com/SitePages/Solution-Development-Best-Practices.aspx?source=https%3A%2F%2Fforeveryidea.sharepoint.com%2FSitePages%2FForms%2FByAuthor.aspx
            
            */
        }

        [Fact]
        public void MakeAssetTag_ReturnsOkAndAddsTag()
        {
            // Arrange

            // Replace this line:
            //var mockStore = new InMemoryAssetTagStore();  ForAdventure.API.ForAdventure.Api.Models
            //IAssetTagStore assetTagStore = new();
            //var mockStore = new ForEveryAdventure.Api.Models.AssetTagStore();
            //var store = new ForAdventure.API.ForAdventure.Api.Models.IAssetTagStore();
            // Replace this line:
            // var store = new ForAdventure.API.ForAdventure.Api.Models.IAssetTagStore();

            // with a mock or concrete implementation of IAssetTagStore.
            // For example, using Moq (if available):
            var mockStore = new Moq.Mock<IAssetTagStore>();
            mockStore.SetupGet(s => s.AssetTags).Returns(new List<AssetTag>());
            var controller = new AssetTagController(mockStore.Object);
            //var controller = new AssetTagController(store.Object);
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
            var assetTagsField = typeof(AssetTagController)
                .GetField("AssetTags", BindingFlags.Static | BindingFlags.NonPublic);
            var store = assetTagsField?.GetValue(null) as List<AssetTag>;

            Assert.NotNull(store);
            Assert.Single(store);
            Assert.Equal(tag.Id, store[0].Id);
        }
    }
}