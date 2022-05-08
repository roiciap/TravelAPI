using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TravelAPI.Entities
{
    public class Lokalizacja
    {
        [Key]
        public int Id { get; set; }

        public string Kraj { get; set; }

        public string Miasto { get; set; }

        public List<Hotel> Hotele { get; set; }
    }
}
