namespace DataAccessLayer.UoW.DAL.Repositories.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUoWRepository<T> where T : class, new()
    {
        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
    }
}
