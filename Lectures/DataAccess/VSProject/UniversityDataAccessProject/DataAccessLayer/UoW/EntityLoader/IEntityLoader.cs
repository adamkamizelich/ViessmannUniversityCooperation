namespace DataAccessLayer.UoW.EntityLoader
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;

    public interface IEntityLoader<T> where T : class, IEntity, new()
    {
        Task<IList<T>> LoadAllAsync();

        Task<T> LoadEntityAsync(int id);
    }
}
