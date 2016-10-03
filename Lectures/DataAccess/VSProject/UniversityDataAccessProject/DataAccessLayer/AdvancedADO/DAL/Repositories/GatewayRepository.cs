namespace DataAccessLayer.AdvancedADO.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccessLayer.AdvancedADO.DAL.Repositories.Interfaces;
    using DataAccessLayer.Common.DomainModel;

    public class GatewayRepository : IRepository<Gateway>
    {
        private readonly IDataAccessAdapter adapter;

        public GatewayRepository()
        {
            this.adapter = new DataAccessAdapter();
        }

        public GatewayRepository(IDataAccessAdapter dataAccessAdapter)
        {
            this.adapter = dataAccessAdapter;
        }

        public async Task<int> AddAsync(Gateway entity)
        {
            string command = $"INSERT INTO Gateway(Name, Address, Serial, Type, IsActive) VALUES({entity.Name}, {entity.Address}, {entity.Serial}, {entity.Type}, {entity.IsActive});SELECT CAST(scope_identity() AS int)";
            entity.Id = (int)await this.adapter.ExecuteScalarAsync(command);
            return entity.Id.Value;
        }

        public Task<bool> UpdateAsync(Gateway entity)
        {
            string command =
                $"UPDATE Gateway SET Name={entity.Name}, Address={entity.Address}, Serial={entity.Serial}, Type={entity.Type}, IsActive={entity.IsActive} WHERE Id={entity.Id} AND RowVersion={entity.RowVersion}";

            return this.adapter.ExecuteNonQueryAsync(command);
        }

        public Task<bool> DeleteAsync(Gateway entity)
        {
            string command = $"DELETE FROM Gateway WHERE Id = {entity.Id}";
            return this.adapter.ExecuteNonQueryAsync(command);
        }

        public async Task<IList<Gateway>> GetAllAsync()
        {
            string command = "SELECT Id, Name, Address, Serial, Type, IsActive, RowVersion FROM [Gateway]";
            return await this.adapter.ExecuteReaderAsync<Gateway>(command);
        }

        public async Task<Gateway> GetByIdAsync(int id)
        {
            string command = $"SELECT Id, Name, Address, Serial, Type, IsActive, RowVersion FROM [Gateway] WHERE Id = {id}";
            var list =  await this.adapter.ExecuteReaderAsync<Gateway>(command);
            return list.FirstOrDefault();
        }
    }
}
