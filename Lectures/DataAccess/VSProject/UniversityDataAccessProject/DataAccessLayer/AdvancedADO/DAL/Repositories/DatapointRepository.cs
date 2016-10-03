namespace DataAccessLayer.AdvancedADO.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.AdvancedADO.DAL.Repositories.Interfaces;
    using DataAccessLayer.Common.DomainModel;

    public class DatapointRepository : IRepository<Datapoint>
    {
        public Task<int> AddAsync(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Datapoint>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Datapoint> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
