using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Wycieczka
    {
        public int Id { get; set; }

        public int RezerwacjaId { get; set; }

        public int HotelId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }

        [ForeignKey("RezerwacjaId")]
        public Rezerwacja Rezerwacja{ get; set; }



    }
}
