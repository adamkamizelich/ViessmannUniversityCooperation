namespace DataAccessLayer.UoW.EntityLoader
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.UoW.CommanBuilder;
    using DataAccessLayer.UoW.DAL;

    public class EntityLoader<T> : IEntityLoader<T> where T : class, IEntity, new()
    {
        private readonly ICommandBuilder commandBuilder;

        private readonly IDataAccessAdapter dataAccessAdapter;

        public EntityLoader()
        {
            this.commandBuilder = new CommandBuilder();
            this.dataAccessAdapter = new DataAccessAdapter();
        }

        public EntityLoader(ICommandBuilder commandBuilder, IDataAccessAdapter dataAccessAdapter)
        {
            this.commandBuilder = commandBuilder;
            this.dataAccessAdapter = dataAccessAdapter;
        }

        public async Task<IList<T>> LoadAllAsync()
        {
            var command = this.commandBuilder.BuildGetAll<T>();
            return await this.dataAccessAdapter.ExecuteReaderAsync<T>(command);
        }

        public async Task<T> LoadEntityAsync(int id)
        {
            var command = this.commandBuilder.BuildGetById<T>(id);
            var list = await this.dataAccessAdapter.ExecuteReaderAsync<T>(command);

            return list.SingleOrDefault();
        }
    }
}
