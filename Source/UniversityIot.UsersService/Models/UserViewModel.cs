namespace UniversityIot.UsersService.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class UserViewModel
    {
        public UserViewModel()
        {
            UserGateways = new List<UserGatewayViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CustomerNumber { get; set; }

        public string Password { get; set; }

        public ICollection<UserGatewayViewModel> UserGateways { get; set; }
    }
}