namespace DataAccessLayer.UoW.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DataAccessLayer.AdvancedADO.DAL.Repositories.Interfaces;
    using DataAccessLayer.UoW.DAL.Repositories.Interfaces;

    public abstract class UoWRepositoryBase<T> : IUoWRepository<T> where T : class, new()
    {
        protected readonly UnitOfWork UnitOfWork;

        protected UoWRepositoryBase(UnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public abstract T Add(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        public abstract Task<IList<T>> GetAllAsync();

        public abstract Task<T> GetByIdAsync(int id);
    }
}
