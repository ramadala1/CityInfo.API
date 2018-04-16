using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class PointsOfInterestsController : Controller
    {
        [HttpGet("{cityId}/PointsOfInterests")]
        public IActionResult GetPointsOfInterests(int cityId)
        {
            var result = CityDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityId).pointsOfInterests;

            if (result == null)
                return NotFound();
            return Ok(result);
        }



        [HttpGet("{cityId}/PointsOfInterests/{Id}",Name ="GetPointofInterest")]
        public IActionResult GetPointOfInterest(int cityId, int Id)
        {
            var result = CityDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityId);
            if (result == null)
                return NotFound();
            var PointofInterest = result.pointsOfInterests.FirstOrDefault(x => x.Id == Id);
            if (PointofInterest == null)
                return NotFound();
            return Ok(PointofInterest);
        }
        [HttpPost("{cityID}/PointsOfInterests")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody]PointsOfInterestsForCreationDto pointsOfInterests)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityId);
            if (city == null)
                return NotFound();
            if (!ModelState.IsValid)
                return NotFound();
            var maxPointOfInterestId = CityDataStore.Current.Cities.SelectMany(x => x.pointsOfInterests).Max(x => x.Id);
            var finalPointOfInterest = new PointsOfInterests()
            {
                Id = ++maxPointOfInterestId,
                Name = pointsOfInterests.Name,
                Description = pointsOfInterests.Description
            };
            city.pointsOfInterests.Add(finalPointOfInterest);
            return CreatedAtRoute("GetPointofInterest", new { cityId = city.ID, id = finalPointOfInterest.Id }, finalPointOfInterest);
        }

        [HttpPut("{cityId}/PointsOfInterests/{Id}")]
        public IActionResult UpdatePointOfInterest(int cityId,int Id, 
            [FromBody]PointOfInterestForUpdateDto pointofinterest)
        {
            if (pointofinterest == null || !ModelState.IsValid)
                return BadRequest();

            var city = CityDataStore.Current.Cities.FirstOrDefault(x => x.ID == cityId);
            if (city == null)
                return NotFound();
            var pointofinterestFromStore = city.pointsOfInterests.FirstOrDefault(x => x.Id == Id);
            if (pointofinterestFromStore == null)
                return NotFound();
            pointofinterestFromStore.Name = pointofinterest.Name;
            pointofinterestFromStore.Description = pointofinterest.Description;
            return NoContent();
        }
    }
}
