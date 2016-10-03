namespace DataAccessLayer.AdvancedADO.DAL.Repositories.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class, new()
    {
        Task<int> AddAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
    }
}
