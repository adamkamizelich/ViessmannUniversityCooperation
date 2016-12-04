namespace UniversityIot.UsersService.Models
{
    using UniversityIot.Enums;

    public class UserGatewayViewModel
    {
        public int Id { get; set; }

        public string GatewaySerial { get; set; }

        public string AccessType { get; set; }
    }
}