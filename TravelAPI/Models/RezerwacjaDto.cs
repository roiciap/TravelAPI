using System.Collections.Generic;

namespace TravelAPI.Models
{
    public class RezerwacjaDto
    {
        public string Data { get; set; }
        public List<WycieczkaDto> Wycieczki { get; set; }

    }
}
