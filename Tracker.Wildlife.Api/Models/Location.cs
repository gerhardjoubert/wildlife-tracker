using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Wildlife.Api.Models
{
    public class Location
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime Timestamp { get; set; }
    }
}