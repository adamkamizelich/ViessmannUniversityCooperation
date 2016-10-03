namespace DataAccessLayer.Common.DomainModel
{
    public class Controller : IEntity
    {
        public int? Id { get; set; }

        public string Serial { get; set; }

        public int? GatewayId => this.Gateway.Id;

        public Gateway Gateway { get; set; }

        public ControllerStatus Status { get; set; }

        public byte[] RowVersion { get; set; }

        public int? ControllerTypeId => this.ControllerType.Id;

        public ControllerType ControllerType { get; set; }
    }
}
