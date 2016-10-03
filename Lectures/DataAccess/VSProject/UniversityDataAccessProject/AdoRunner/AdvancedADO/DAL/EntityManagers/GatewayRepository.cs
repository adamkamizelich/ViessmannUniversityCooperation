namespace AdoDataAccessLayer.AdvancedADO.DAL.EntityManagers
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using AdoDataAccessLayer.AdvancedADO.DomainModel;

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

        public async Task<bool> AddAsync(Gateway entity)
        {
            StringBuilder sb = new StringBuilder();
            string command = $"INSERT INTO Gateway(Name, Address, Serial, Type, IsActive) VALUES({entity.Name}, {entity.Address}, {entity.Serial}, {entity.Type}, {entity.IsActive});";
            return await this.adapter.ExecuteNonQueryAsync(command);
        }

        public Task<bool> UpdateAsync(Gateway entity)
        {
            string command =
                $"UPDATE Gateway SET Name={entity.Name}, Address={entity.Address}, Serial={entity.Serial}, Type={entity.Type}, IsActive={entity.IsActive} WHERE Id={entity.Id} AND RowVersion={entity.RowVersion}";

            return this.adapter.ExecuteNonQueryAsync(command);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Gateway>> GetAllAsync()
        {
            string command = "SELECT Name, Address, Serial, Type, IsActive, RowVersion FROM [Gateway]";
            return await this.adapter.ExecuteReaderAsync<Gateway>(command);
        }
    }
}
