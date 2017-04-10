using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tracker.Wildlife.Api.Models
{
    public class Species
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}