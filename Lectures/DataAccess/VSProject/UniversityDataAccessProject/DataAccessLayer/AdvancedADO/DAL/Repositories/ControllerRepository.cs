namespace DataAccessLayer.AdvancedADO.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.AdvancedADO.DAL.Repositories.Interfaces;
    using DataAccessLayer.Common.DomainModel;

    public class ControllerRepository : IRepository<Controller>
    {
        public Task<int> AddAsync(Controller entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Controller entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Controller id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Controller>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Controller> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
