namespace AdoDataAccessLayer.AdvancedADO.DomainModel
{
    public class Controller
    {
        public int Id { get; set; }

        public string Serial { get; set; }

        public Gateway Gateway { get; set; }

        public ControllerStatus Status { get; set; }

        public byte[] RowVersion { get; set; }

        public ControllerType ControllerType { get; set; }
    }
}
