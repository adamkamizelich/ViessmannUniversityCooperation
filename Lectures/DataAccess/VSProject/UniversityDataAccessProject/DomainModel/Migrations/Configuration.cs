namespace DomainModel.Migrations
{
    using System.Data.Entity.Migrations;

    using DomainModel.Entities;

    /// <summary>
    /// Configuration for migration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<DeviceContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeviceContext context)
        {
            ControllerType ct1 = new ControllerType()
                                     {
                                         Category = 1,
                                         HardwareIndex = 10,
                                         SoftwareIndexMin = 0,
                                         SoftwareIndexMax = 20
                                     };

            ControllerType ct2 = new ControllerType()
                                     {
                                         Category = 2,
                                         HardwareIndex = 10,
                                         SoftwareIndexMin = 20,
                                         SoftwareIndexMax = 30
                                     };

            context.ControllerTypes.AddOrUpdate(x => x.Id, ct1);
            context.ControllerTypes.AddOrUpdate(x => x.Id, ct2);

            Gateway gateway = new Gateway()
                                  {
                                      Address = "Some address",
                                      Name = "GatewayName",
                                      Serial = "433338771000"
                                  };

            context.Gateways.AddOrUpdate(x => x.GatewayId, gateway);

            Controller controller1 = new Controller()
                                         {
                                             Gateway = gateway,
                                             Serial = "9998877",
                                             ControllerType = ct1,
                                             Status = ControllerStatus.Operating
                                         };
            context.Controllers.AddOrUpdate(x => x.ControllerKey, controller1);

            Controller controller2 = new Controller()
                                         {
                                             Gateway = gateway,
                                             ControllerType = ct2,
                                             Status = ControllerStatus.Invalid,
                                             Serial = "999113"
                                         };

           context.Controllers.AddOrUpdate(x => x.ControllerKey, controller2);

            Datapoint dp1 = new Datapoint()
                                {
                                    Name = "temp_outside",
                                    HexAddress = "2300"
                                };

            context.Datapoints.AddOrUpdate(x => x.Id, dp1);

            Datapoint dp2 = new Datapoint()
                                {
                                    Name = "temp_inside",
                                    HexAddress = "2330"
                                };

            context.Datapoints.AddOrUpdate(x => x.Id, dp2);

            Datapoint dp3 = new Datapoint()
                                {
                                    Name = "set_program",
                                    HexAddress = "4020"
                                };

            context.Datapoints.AddOrUpdate(x => x.Id, dp3);

            ct1.Datapoints.Add(dp1);
            ct1.Datapoints.Add(dp2);

            ct2.Datapoints.Add(dp1);
            ct2.Datapoints.Add(dp3);

            context.SaveChanges();
        }
    }
}
