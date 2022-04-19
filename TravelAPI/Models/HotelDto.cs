using System.Collections.Generic;

namespace TravelAPI.Models
{
    public class HotelDto
    {
       // public int Id { get; set; }
        public string Nazwa { get; set; }
        public int IloscGwiazdek { get; set; }
        public List<PokojDto> Pokoje { get; set; }
    }
}
