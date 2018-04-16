﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NoOfPointsOfInterests
        { get
            {
                return pointsOfInterests.Count();
            }
        }

        public List<PointsOfInterests> pointsOfInterests { get; set; }
        = new List<PointsOfInterests>();
    }
}
