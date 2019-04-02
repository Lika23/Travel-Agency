using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class FavoriteTour
    {
        public int FavoriteTourId { get; set; }
        public Tour Tour { get; set; }
        public ApplicationUser User { get; set; }
    }
}