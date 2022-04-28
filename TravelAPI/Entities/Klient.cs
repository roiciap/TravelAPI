using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAPI.Entities
{
    public class Klient
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public List<Rezerwacja> Rezerwacje { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
