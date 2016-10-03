namespace DataAccessLayer.UoW.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.UoW;

    public class DatapointUoWRepository : UoWRepositoryBase<Datapoint>
    {
        public DatapointUoWRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override Datapoint Add(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IList<Datapoint>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public override Task<Datapoint> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
