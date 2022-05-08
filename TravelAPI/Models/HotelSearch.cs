using System;
using TravelAPI.Entities;

namespace TravelAPI.Models
{
    public class HotelSearch
    {
        public int minCost { get; set; }
        public int maxCost { get; set; }
        public string odKiedy { get; set; }
        public string doKiedy { get; set; }
        public string Location { get; set; }
    }
}
