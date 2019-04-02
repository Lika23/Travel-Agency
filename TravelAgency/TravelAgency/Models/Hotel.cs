using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public int Class { get; set; }
        public string Address { get; set; }
        public string Nutrition { get; set; }
        public int ResortId { get; set; }
        public Resort Resort { get; set; }
        public List<Tour> Tours { get; set; }
        public List<Picture> Pictures { get; set; }
        
        public Hotel()
        {
            Tours = new List<Tour>();
            Pictures = new List<Picture>();
        }
    }
}