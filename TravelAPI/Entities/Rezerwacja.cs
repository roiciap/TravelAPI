using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Rezerwacja
    {
        [Key]
        public int Id { get; set; }
        public List<Wycieczka> Wycieczki { get; set; }

        public int KlientId { get; set; }
        public int Cost { get; set; }
        public bool Paid { get; set; }
        public DateTime PaymentExpires { get; set; }

        [ForeignKey("KlientId")]
        public Klient Klient { get; set; }
    }
}
