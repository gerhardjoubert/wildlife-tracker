using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Wildlife.Api.Models
{
    public class MapData
    {
        public int AnimalId { get; set; }
        public string Species { get; set; }
        public string Category { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}