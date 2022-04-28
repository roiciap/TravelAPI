using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Wycieczka
    {
        public int Id { get; set; }

        public int RezerwacjaId { get; set; }

        public int PokojId { get; set; }

        [ForeignKey("PokojId")]
        public Pokoj Pokoj { get; set; }

        [ForeignKey("RezerwacjaId")]
        public Rezerwacja Rezerwacja{ get; set; }



    }
}
