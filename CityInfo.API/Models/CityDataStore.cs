using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();
        public List<CityDto> Cities { get; set; }
        public CityDataStore()
        {
            Cities = new List<CityDto>()
            {
                 new CityDto()
                 {
                     ID = 1, Name = "Chicago", Description = "Chicago is a old city",
                 pointsOfInterests = new List<PointsOfInterests>()
                 {
                     new PointsOfInterests(){Id = 1,Name ="Willis Tower",Description ="One of the tollest building in United States"},
                     new PointsOfInterests(){Id=2,Name="Lake Shore Drive", Description = "Driving along with the Michigan lake while enjoying amazing view of lake and down town"}
                 } },
                new CityDto() {
                    ID = 2, Name = "New York", Description = "New York also a old city",
                pointsOfInterests = new List<PointsOfInterests>(){
                    new PointsOfInterests(){Id=1,Name="Empire State Building",Description ="One of the Oldest and tollest building" },
                    new PointsOfInterests(){Id = 2,Name="World Trade Center",Description ="One of the Business center in New York"}
                } },
                new CityDto(){ID=3,Name="Baltimore",Description="Baltimore is a beautiful city",
                    pointsOfInterests = new List<PointsOfInterests>() {
                        new PointsOfInterests(){Id=1,Name="Lake ",Description="i don't know much about this city now , will update after one month" }
                    } }
            };            
        }

            

              
    }
}
