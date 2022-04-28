using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Pokoj
    {
        public int Id { get; set; }
        public int koszt { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        public List<Wycieczka> Wycieczki { get; set; }
    }
}
