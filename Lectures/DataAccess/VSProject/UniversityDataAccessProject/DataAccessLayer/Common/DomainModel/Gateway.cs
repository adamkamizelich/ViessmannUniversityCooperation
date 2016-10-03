namespace DataAccessLayer.Common.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Gateway : IEntity
    {
        public Gateway()
        {
            this.Controllers = new List<Controller>();
        }

        public int? Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Serial { get; set; }

        public GatewayType Type { get; set; }

        public bool IsActive { get; private set; }

        public byte[] RowVersion { get; set; }

        internal IList<Controller> Controllers { get; set; }

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

        public IReadOnlyCollection<Controller> GetControllers()
        {
            return new ReadOnlyCollection<Controller>(this.Controllers.ToList());
        }

        public void Activate()
        {
            if (this.Type == GatewayType.Lancard)
            {
                // Some additional action
            }

            if (this.Controllers.Any(controller => controller.Status != ControllerStatus.Operating))
            {
                throw new InvalidOperationException("Cannot activate non operating gateway");
            }
            
            this.IsActive = true;
        }
    }
}
