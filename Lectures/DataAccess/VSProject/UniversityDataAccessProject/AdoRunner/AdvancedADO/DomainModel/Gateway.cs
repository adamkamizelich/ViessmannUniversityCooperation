namespace AdoDataAccessLayer.AdvancedADO.DomainModel
{
    using System.Collections.Generic;

    public class Gateway
    {
        public Gateway()
        {
            this.Controllers = new List<Controller>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Serial { get; set; }

        public GatewayType Type { get; set; } 

        public bool IsActive { get; private set; }

        public byte[] RowVersion { get; set; }

        protected IList<Controller> Controllers { get; set; }

        public bool AddController(Controller controller)
        {
            if (controller.Status != ControllerStatus.Invalid)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(controller.Serial))
            {
                return false;
            }

            controller.Gateway = this;
            this.Controllers.Add(controller);

            return true;
        }

        public void Activate()
        {
            if (this.Type == GatewayType.Lancard)
            {
                // Some additional action
            }

            this.IsActive = true;
        }
    }
}
