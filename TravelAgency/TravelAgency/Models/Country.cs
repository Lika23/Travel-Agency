using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Population { get; set; }
        public string OfficialLanguage { get; set; }
        public List<Resort> Resorts { get; set; }
        public List<Picture> Pictures { get; set; }
        public Country()
        {
            Resorts = new List<Resort>();
            Pictures = new List<Picture>();
        }
    }
}