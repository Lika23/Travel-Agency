using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Resort
    {
        public int ResortId { get; set; }
        public string Name { get; set; }
        public string Infrastructure { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public List<Hotel> Hotels { get; set; }
        public Resort()
        {
            Hotels = new List<Hotel>();
        }
    }
}