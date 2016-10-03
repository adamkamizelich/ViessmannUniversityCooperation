namespace DataAccessLayer.UoW.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class DataAccessAdapter : IDataAccessAdapter
    {
        private const string ConnectionString = "Data Source=FUE003W1602\\SQLSERVER;Initial Catalog=University; Integrated Security=true";

        public async Task<bool> ExecuteNonQueryAsync(string commandString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    try
                    {
                        connection.Open();
                        await command.ExecuteNonQueryAsync();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
        }

        public async Task<object> ExecuteScalarAsync(string commandString)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    try
                    {
                        connection.Open();
                        return await command.ExecuteScalarAsync();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }
                }
            }
        }

        public async Task<IList<T>> ExecuteReaderAsync<T>(string commandString) where T : class, new()
        {
            List<T> list = new List<T>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                T entity = new T();
                                foreach (var propertyInfo in typeof(T).GetProperties())
                                {
                                    var value = reader[propertyInfo.Name];
                                    if (!(value is DBNull))
                                    {
                                        propertyInfo.SetValue(entity, value);
                                    }
                                }

                                list.Add(entity);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return Enumerable.Empty<T>().ToList();
                    }
                }

                return list;
            }
        }
    }
}
