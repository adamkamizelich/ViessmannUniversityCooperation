namespace UniversityIot.UsersDataAccess.Models
{
    using UniversityIot.Enums;

    public class UserGateway
    {
        public int Id { get; set; }

        public string GatewaySerial { get; set; }

        public GatewayAccessType AccessType { get; set; }
    }
}