namespace AdoDataAccessLayer.AdvancedADO.DAL.EntityManagers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AdoDataAccessLayer.AdvancedADO.DomainModel;

    class ControllerRepository : IRepository<Controller>
    {
        public Task<bool> AddAsync(Controller entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Controller entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Controller>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
