namespace AdoDataAccessLayer.AdvancedADO
{
    using System;
    using System.Threading.Tasks;

    using AdoDataAccessLayer.AdvancedADO.DAL.EntityManagers;
    using AdoDataAccessLayer.AdvancedADO.DomainModel;
    using AdoDataAccessLayer.ExternalServices;

    public class SimpleRepositoryService
    {
        private readonly GatewayRepository gatewayRepository;

        private readonly ControllerRepository controllerRepository;

        private readonly IExternalService externalService;

        public SimpleRepositoryService()
        {
            this.gatewayRepository = new GatewayRepository();
            this.controllerRepository = new ControllerRepository();
            this.externalService = new ExternalServiceMock();
        }

        // Business transaction
        public async Task RegisterNewGatewayWithControllerAsync(string controllerSerial, string gatewaySerial)
        {
            if (!this.externalService.IsGatewayProduced(gatewaySerial))
            {
                throw new InvalidOperationException("Gateway does not exist");
            }

            Gateway gateway = new Gateway()
            {
                Name = "default installation",
                Serial = gatewaySerial
            };

            var controllerStatus = this.externalService.GetControllerStatus(controllerSerial);

            if (controllerStatus == ControllerStatus.Maintenance)
            {
                // perhaps invoke some additional action
                // e.g. send email to subscribed people.
            }

            var controller = new Controller()
            {
                Serial = controllerSerial,
                Status = controllerStatus
            };

            gateway.AddController(controller);
            gateway.Activate();

            await this.gatewayRepository.AddAsync(gateway);

            // What about transaction?
            await this.controllerRepository.AddAsync(controller);
        }
    }
}
