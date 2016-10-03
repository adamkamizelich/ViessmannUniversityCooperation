namespace DataAccessLayer.UoW.CommanBuilder
{
    using DataAccessLayer.Common.DomainModel;

    public interface ICommandBuilder
    {
        string BuildAdd<T>(T entity) where T : class, IEntity, new();

        string BuildUpdate<T>(T entity) where T : class, IEntity, new();

        string BuildDelete<T>(int? entityId) where T : class, IEntity, new();

        string BuildGetAll<T>() where T : class, IEntity, new();

        string BuildGetById<T>(int entityId) where T : class, IEntity, new();

        string BuildManyToManyConnection<T1, T2>(T1 entity1, T2 entity2) 
            where T1 : class, IEntity, new()
            where T2 : class, IEntity, new();
    }
}
