using System.Collections.Generic;

namespace TravelAPI.Models
{
    public class HotelDto
    {
       // public int Id { get; set; }
        public string Nazwa { get; set; }
        public int IloscGwiazdek { get; set; }
        public int iloscPokoi { get; set; }

        public string Kraj { get; set; }
        public string Miasto { get; set; }
        
        public int koszt { get; set; }
    }
}
