using System.Collections.Generic;

namespace TravelAPI.Entities
{
    public class Klient
    {
        public int Id { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public List<Rezerwacja> Rezerwacje { get; set; }
    }
}
