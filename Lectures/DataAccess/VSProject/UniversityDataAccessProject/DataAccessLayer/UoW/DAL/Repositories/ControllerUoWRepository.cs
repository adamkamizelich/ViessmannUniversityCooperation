namespace DataAccessLayer.UoW.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.UoW;

    public class ControllerUoWRepository : UoWRepositoryBase<Controller>
    {
        public ControllerUoWRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Controller Add(Controller entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Controller entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Controller entity)
        {
            throw new NotImplementedException();
        }

        public override Task<IList<Controller>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public override Task<Controller> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
