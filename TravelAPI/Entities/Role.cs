using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Klient> users { get; set; }
    }
}
