using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Picture
    {
        public int PictureId { get; set; }
        public string Url { get; set; }
        public Country Country { get; set; }
        public Hotel Hotel { get; set; }
    }
}