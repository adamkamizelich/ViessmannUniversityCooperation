namespace DataAccessLayer.UoW.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;

    public class ControllerTypeUoWRepository : UoWRepositoryBase<ControllerType>
    {
        public ControllerTypeUoWRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override ControllerType Add(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IList<ControllerType>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public override Task<ControllerType> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }


        public Task<ControllerType> GetByHardwareIndexAndSoftwareIndexAsync(int hardwareIndex, int softwareIndex)
        {
            throw new System.NotImplementedException();
        }
    }
}
