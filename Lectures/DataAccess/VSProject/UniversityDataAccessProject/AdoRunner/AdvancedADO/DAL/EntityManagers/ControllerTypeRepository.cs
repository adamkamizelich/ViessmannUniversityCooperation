namespace AdoDataAccessLayer.AdvancedADO.DAL.EntityManagers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoDataAccessLayer.AdvancedADO.DomainModel;

    public class ControllerTypeRepository : IRepository<ControllerType>
    {
        public Task<bool> AddAsync(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ControllerType>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
