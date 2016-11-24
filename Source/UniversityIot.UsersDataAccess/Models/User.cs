namespace UniversityIot.UsersDataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.UserGateways = new List<UserGateway>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(10)]
        public string CustomerNumber { get; set; }

        public string Password { get; set; }

        public ICollection<UserGateway> UserGateways { get; set; }
    }
}