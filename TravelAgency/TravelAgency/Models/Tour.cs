using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Tour
    {
        public int TourId { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}