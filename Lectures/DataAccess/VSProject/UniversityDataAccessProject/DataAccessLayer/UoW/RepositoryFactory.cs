namespace DataAccessLayer.UoW
{
    using DataAccessLayer.UoW.DAL.Repositories;

    public class RepositoryFactory
    {
        private readonly UnitOfWork unitOfWork;

        public RepositoryFactory(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public GatewayUoWRepository GetGatewayRepository()
        {
            return new GatewayUoWRepository(this.unitOfWork);
        }

        public ControllerUoWRepository GetControllerRepository()
        {
            return new ControllerUoWRepository(this.unitOfWork);
        }

        public ControllerTypeUoWRepository GetControllerTypeRespository()
        {
            return new ControllerTypeUoWRepository(this.unitOfWork);
        }

        public DatapointUoWRepository GetDatapointRepository()
        {
            return new DatapointUoWRepository(this.unitOfWork);
        }
    }
}
