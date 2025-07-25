using Microsoft.AspNetCore.Mvc;
using ForEveryAdventure.Api.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ForAdventure.Api.Controllers;
using ForAdventure.API.ForAdventure.Api.Models;
using Moq;

namespace ForAdventure.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetTagController : ControllerBase
    {
        private readonly IAssetTagStore _store;
        public AssetTagController(IAssetTagStore store)         {
            _store = store;
        }


        // In-memory store for demonstration
        //private static readonly List<AssetTag> AssetTags = new();
        private static readonly List<TripPlan> TripPlans = new();
        private readonly Mock<IAssetTagStore> mockStore = new Mock<IAssetTagStore>();

        [HttpPost("api/MakeAssetTag")]
        //public IActionResult UpdateTripPlan([FromBody] TripPlan tripPlan)
        public IActionResult MakeAssetTag([FromBody] Guid userId)
        {
            if (userId == Guid.Empty)
                return BadRequest("UserId is required.");

            var newTag = new AssetTag
            {
                Id = Guid.NewGuid(),
                TagCode = Guid.NewGuid().ToString("N"),
                UserId = userId,
                EmergencyContacts = new List<EmergencyContact>(),
                TripPlans = new List<TripPlan>()
            };

            if (_store.AssetTags == null)
                throw new InvalidOperationException("AssetTags list is not initialized.");

            _store.AssetTags.Add(newTag); // Persist the tag

            return Ok(newTag);
        }

        [HttpPost("api/AddPlanLogistics")]
        public IActionResult UpdateTripPlan([FromBody] TripPlan tripPlan)
        {
            tripPlan.TripIdentifier = Guid.NewGuid();
            TripPlans.Add(tripPlan);
            return Ok(tripPlan);
        }

        [HttpGet("api/ShareAssetTag/{tagCode}")]
        public ActionResult GetAssetTag(string tagCode)
        {
            //var tag = AssetTags.Find(t => t.TagCode == tagCode);
            if (tagCode == null) return NotFound();
            return Ok(tagCode);
        }

        [HttpPost("api/Emergency/{tagCode}/alert")]
        public IActionResult SendAlert(string tagCode)
        {
            //var tag = AssetTags.Find(t => t.TagCode == tagCode);
            if (tagCode == null) return NotFound();
            // Here you would notify emergency contacts (email/SMS integration)
            return Ok("Alert sent to emergency contacts.");
        }
    }
}