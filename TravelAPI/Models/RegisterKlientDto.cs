using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelAPI.Models
{
    public class RegisterKlientDto
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public int roleId { get; set; }
    }
}
