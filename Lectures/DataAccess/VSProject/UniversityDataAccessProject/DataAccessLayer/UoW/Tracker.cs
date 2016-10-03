namespace DataAccessLayer.UoW
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccessLayer.Common.DomainModel;
    using DataAccessLayer.UoW.EntityLoader;

    public class Tracker<T> where T : class, IEntity, new()
    {
        internal readonly IList<T> Added;

        internal readonly IList<T> Updated;

        internal readonly IList<T> Deleted;

        private readonly IDictionary<int, T> cachedEntities;

        private readonly IEntityLoader<T> entityLoader;

        public Tracker(IEntityLoader<T> entityLoader)
        {
            this.Added = new List<T>();
            this.Updated = new List<T>();
            this.Deleted = new List<T>();
            this.cachedEntities = new Dictionary<int, T>();
            this.entityLoader = entityLoader;
        }

        public Tracker() : this(new EntityLoader<T>())
        {
            this.entityLoader = new EntityLoader<T>();
        }

        public void Add(T entity)
        {
            if (entity.Id.HasValue)
            {
                throw new InvalidOperationException("Entity with given Id already exists");
            }

            if (this.Added.Contains(entity))
            {
                return;
            }

            this.Added.Add(entity);
        }

        public void Update(T entity)
        {
            if (!entity.Id.HasValue)
            {
                throw new InvalidOperationException("Cannot update entity when it does not exist in database.");
            }

            if (this.Added.Any(x => x.Id == entity.Id))
            {
                throw new InvalidOperationException("Cannot update entity when it has been added.");
            }

            if (this.Updated.Any(x => x.Id == entity.Id))
            {
                throw new InvalidOperationException("Entity has been already marked for update.");
            }

            if (this.Deleted.Any(x => x.Id == entity.Id))
            {
                throw new InvalidOperationException("Cannot update entity when it has been marked for deletion.");
            }

            this.Updated.Add(entity);
        }

        public void Delete(T entity)
        {
            if (!entity.Id.HasValue)
            {
                throw new InvalidOperationException("Cannot delete entity when it does not exist in database.");
            }

            if (this.Updated.Any(x => x.Id == entity.Id))
            {
                var element = this.Updated.Single(x => x.Id == entity.Id);
                this.Updated.Remove(element);
            }

            if (this.Deleted.Any(x => x.Id == entity.Id))
            {
                return;
            }

            this.Deleted.Add(entity);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            var list = await this.entityLoader.LoadAllAsync();

            foreach (var entity in list.Where(entity => !this.cachedEntities.ContainsKey(entity.Id.Value)))
            {
                this.cachedEntities.Add(entity.Id.Value, entity);
            }

            // should we return entities from Deleted collection as well?
            // should we return updated entities?

            return list;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            if (this.Updated.Any(x => x.Id == id))
            {
                return this.Updated.Single(x => x.Id == id);
            }

            if (this.Deleted.Any(x => x.Id == id))
            {
                return null;
            }

            if (this.cachedEntities.ContainsKey(id))
            {
                return this.cachedEntities[id];
            }

            var entity = await this.entityLoader.LoadEntityAsync(id);
            
            if (entity != null)
            {
                this.cachedEntities.Add(id, entity);
            }

            return entity;
        }
    }
}
