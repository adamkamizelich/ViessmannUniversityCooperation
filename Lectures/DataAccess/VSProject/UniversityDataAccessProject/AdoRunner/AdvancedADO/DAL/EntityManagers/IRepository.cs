namespace AdoDataAccessLayer.AdvancedADO.DAL.EntityManagers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T>
    {
        Task<bool> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<IList<T>> GetAllAsync();
    }
}
