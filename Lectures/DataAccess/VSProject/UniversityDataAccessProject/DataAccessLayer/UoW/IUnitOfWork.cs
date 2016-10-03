namespace DataAccessLayer.UoW
{
    using System;
    using System.Threading.Tasks;

    public interface IUnitOfWork : IDisposable
    {
        RepositoryFactory Factory { get; set; }

        Task SaveAsync();
    }
}
