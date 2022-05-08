using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Rezerwacja
    {
        public int Id { get; set; }
        public List<Wycieczka> Wycieczki { get; set; }

        public int KlientId { get; set; }
        [ForeignKey("KlientId")]
        public Klient Klient { get; set; }
    }
}
