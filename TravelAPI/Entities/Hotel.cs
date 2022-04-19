using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Nazwa { get; set; }

        public int IloscGwiazdek { get; set; }

        public List<Pokoj> Pokoje { get; set; }

        public int LokalizacjaId { get; set; }

        [ForeignKey("LokalizacjaId")]
        public Lokalizacja Lokalizacja { get; set; }
    }
}
