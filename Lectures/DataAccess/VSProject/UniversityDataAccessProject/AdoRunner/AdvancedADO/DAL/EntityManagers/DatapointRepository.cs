namespace AdoDataAccessLayer.AdvancedADO.DAL.EntityManagers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoDataAccessLayer.AdvancedADO.DomainModel;

    public class DatapointRepository : IRepository<Datapoint>
    {
        public Task<bool> AddAsync(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Datapoint entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Datapoint>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
