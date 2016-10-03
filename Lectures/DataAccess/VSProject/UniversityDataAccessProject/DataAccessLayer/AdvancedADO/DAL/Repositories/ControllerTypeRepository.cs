namespace DataAccessLayer.AdvancedADO.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccessLayer.AdvancedADO.DAL.Repositories.Interfaces;
    using DataAccessLayer.Common.DomainModel;

    public class ControllerTypeRepository : IControllerTypeRepository
    {
        private readonly IDataAccessAdapter adapter;

        public ControllerTypeRepository()
        {
            this.adapter = new DataAccessAdapter();
        }

        public Task<int> AddAsync(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(ControllerType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ControllerType>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ControllerType> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ControllerType> GetByHardwareIndexAndSoftwareIndexAsync(int hardwareIndex, int softwareIndex)
        {
            string command = $"SELECT * FROM ControllerType WHERE HardwareIndex = {hardwareIndex} AND SoftwareIndexMin <= {softwareIndex} AND {softwareIndex} < SoftwareIndexMax";
            var list = await this.adapter.ExecuteReaderAsync<ControllerType>(command);
            return list.SingleOrDefault();

        }
    }
}
