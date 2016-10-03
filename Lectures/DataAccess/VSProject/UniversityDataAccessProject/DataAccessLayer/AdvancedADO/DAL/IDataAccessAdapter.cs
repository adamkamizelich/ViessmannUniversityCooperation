namespace DataAccessLayer.AdvancedADO.DAL
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDataAccessAdapter
    {
        Task<bool> ExecuteNonQueryAsync(string commandString);

        Task<object> ExecuteScalarAsync(string commandString);

        Task<IList<T>> ExecuteReaderAsync<T>(string commandString) where T : class, new();
    }
}
