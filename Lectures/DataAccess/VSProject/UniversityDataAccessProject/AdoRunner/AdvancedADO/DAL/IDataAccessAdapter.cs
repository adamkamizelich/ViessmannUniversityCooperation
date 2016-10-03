namespace AdoDataAccessLayer.AdvancedADO.DAL
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataAccessAdapter
    {
        Task<bool> ExecuteNonQueryAsync(string command);

        Task<IList<T>> ExecuteReaderAsync<T>(string command) where T : class, new();
    }
}
