namespace AdoDataAccessLayer.exampleADO
{
    using System;
    using System.Collections.Specialized;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    public class ConnectedModelExample
    {
        private const string ConnectionString = "Data Source=FUE003W1602\\SQLSERVER;Initial Catalog=University; Integrated Security=true";

        private const string QueryString = @"SELECT g.Name as GatewayName, ct.Name as ControllerTypeName 
                FROM Controller c 
                    INNER JOIN Gateway g ON c.GatewayId = g.Id 
                    INNER JOIN ControllerType ct ON c.ControllerTypeId = ct.Id;";

        public async Task ReadAsync()
        {
            var list = new NameValueCollection();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(QueryString, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            
                            while (await reader.ReadAsync())
                            {
                                list.Add(reader.GetString(0), (string)reader["ControllerTypeName"]);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Gateway: {0}\t ControllerType: {1}", list.GetKey(i), list.Get(i));
            }
            
        }
    }
}
