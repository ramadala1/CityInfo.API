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



        [HttpGet("{cityId}/PointsOfInterests/{Id}")]
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
    }
}
