namespace DataAccessLayer.UoW
{
    using System;
    using System.Threading.Tasks;

    using DataAccessLayer.Common;
    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.Common.DTO;
    using DataAccessLayer.Common.ExternalServices;
    using DataAccessLayer.UoW.DAL.Repositories;

    public class UoWRepositoryService : IService
    {
        private readonly IExternalService dummyWebService;

        public UoWRepositoryService()
        {
            this.dummyWebService = new ExternalServiceMock();
        }

        // Business transaction
        public async Task RegisterNewGatewayWithControllerAsync(GatewayData gatewayData, ControllerData controllerData)
        {
            this.CheckConditions(gatewayData, controllerData);

            using (IUnitOfWork uow = new UnitOfWork())
            {
                var gatewayRepository = uow.Factory.GetGatewayRepository();
                var controllerRepository = uow.Factory.GetControllerRepository();
                var controllerTypeRepository = uow.Factory.GetControllerTypeRespository();

                Gateway gateway = new Gateway()
                                      {
                                          Name = gatewayData.Name,
                                          Serial = gatewayData.Serial,
                                          Address = gatewayData.Address
                                      };

                var controller = await this.CreateControllerAsync(controllerData, controllerTypeRepository);

                gateway.AddController(controller);

                gateway.Activate();

                gatewayRepository.Add(gateway);

                controllerRepository.Add(controller);

                await uow.SaveAsync();
            }
        }

        private static void NotifyIfRequired(ControllerStatus controllerStatus)
        {
            if (controllerStatus == ControllerStatus.Maintenance)
            {
                // perhaps invoke some additional action
                // e.g. send email to subscribed people.
            }
        }

        private async Task<Controller> CreateControllerAsync(ControllerData controllerData, ControllerTypeUoWRepository repository)
        {
            var controllerStatus = this.dummyWebService.GetControllerStatus(controllerData.Serial);

            NotifyIfRequired(controllerStatus);

            var controllerType = await repository.GetByHardwareIndexAndSoftwareIndexAsync(controllerData.HardwareIndex, controllerData.SoftwareIndex);

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
