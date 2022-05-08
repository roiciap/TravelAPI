using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string ImgUri { get; set; }
        public string Nazwa { get; set; }
        public int koszt { get; set; }
        public int IloscGwiazdek { get; set; }//
        public int iloscPokoi { get; set; }
        public int LokalizacjaId { get; set; }
        [ForeignKey("LokalizacjaId")]
        public Lokalizacja Lokalizacja { get; set; }
        public List<Wycieczka> Wycieczka { get; set; }
    }
}
