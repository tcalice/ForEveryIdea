using Microsoft.AspNetCore.Mvc;
using ForEveryAdventure.Api.Models;
using System.Collections.Generic;
using ForEveryAdventure.Api.Services;

namespace ForAdventure.Api.Controllers
{
    [ApiController]
    [Route("api/AddPlanLogistics")]
    public class TripPlanController : ControllerBase
    {
        private static readonly List<TripPlan> TripPlans = new();

        [HttpPost]
        public IActionResult UpdateTripPlan([FromBody] TripPlan tripPlan)
        {
            TripPlans.Add(tripPlan);

            var narrative = ForAdventureLogic.generateTripPlanNarrative(tripPlan);

            return Ok(new { narrative });
        }
    }
}