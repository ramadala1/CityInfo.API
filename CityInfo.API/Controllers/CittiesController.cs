using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CittiesController : Controller
    {
       // [HttpGet("api/Cities")]
        public IActionResult GetCities()
        {
            return Ok(CityDataStore.Current.Cities);
        }
        [HttpGet("{Id}")]
        public IActionResult GetCity(int Id)
        {
            var result = CityDataStore.Current.Cities.FirstOrDefault(x => x.ID == Id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
