namespace DataAccessLayer.AdvancedADO
{
    using System;
    using System.Threading.Tasks;

    using DataAccessLayer.AdvancedADO.DAL.Repositories;
    using DataAccessLayer.Common;
    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.Common.DTO;
    using DataAccessLayer.Common.ExternalServices;

    public class SimpleRepositoryService : IService
    {
        private readonly GatewayRepository gatewayRepository;

        private readonly ControllerRepository controllerRepository;

        private readonly ControllerTypeRepository controllerTypeRepository;

        private readonly IExternalService dummyWebService;

        public SimpleRepositoryService()
        {
            this.gatewayRepository = new GatewayRepository();
            this.controllerRepository = new ControllerRepository();
            this.dummyWebService = new ExternalServiceMock();
            this.controllerTypeRepository = new ControllerTypeRepository();
        }

        // Business transaction
        public async Task RegisterNewGatewayWithControllerAsync(GatewayData gatewayData, ControllerData controllerData)
        {
            this.CheckConditions(gatewayData, controllerData);

            Gateway gateway = new Gateway()
            {
                Name = gatewayData.Name,
                Serial = gatewayData.Serial,
                Address = gatewayData.Address
            };

            var controller = await this.CreateControllerAsync(controllerData);

            gateway.AddController(controller);

            gateway.Activate();

            await this.gatewayRepository.AddAsync(gateway);
            
            // What about transaction?
            await this.controllerRepository.AddAsync(controller);
        }

        private static void NotifyIfRequired(ControllerStatus controllerStatus)
        {
            if (controllerStatus == ControllerStatus.Maintenance)
            {
                // perhaps invoke some additional action
                // e.g. send email to subscribed people.
            }
        }

        private async Task<Controller> CreateControllerAsync(ControllerData controllerData)
        {
            var controllerStatus = this.dummyWebService.GetControllerStatus(controllerData.Serial);

            NotifyIfRequired(controllerStatus);

            var controllerType = await this.controllerTypeRepository.GetByHardwareIndexAndSoftwareIndexAsync(controllerData.HardwareIndex, controllerData.SoftwareIndex);

            var controller = new Controller()
                                 {
                                     Serial = controllerData.Serial,
                                     Status = controllerStatus,
                                     ControllerType = controllerType,
                                 };
            return controller;
        }

        private void CheckConditions(GatewayData gatewayData, ControllerData controllerData)
        {
            if (string.IsNullOrEmpty(gatewayData.Serial))
            {
                throw new ArgumentNullException(nameof(gatewayData.Serial));
            }

            if (!this.dummyWebService.IsGatewayProduced(gatewayData.Serial))
            {
                throw new InvalidOperationException("Gateway does not exist");
            }

            if (!this.dummyWebService.IsControllerProduced(controllerData.Serial))
            {
                throw new InvalidOperationException("Controller does not exist");
            }
        }
    }
}
