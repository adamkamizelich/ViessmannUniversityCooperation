namespace ADO
{
    using System;
    using System.Data.SqlClient;

    public  class ConnectedModelExample
    {
        private const string ConnectionString = "Data Source=(SQLSERVER);Initial Catalog=University;" + "Integrated Security=true";

        private const string QueryString = @"SELECT g.Name as GatewayName, ct.Name as ControllerTypeName 
                FROM Controller c 
                    INNER JOIN Gateway g ON c.GatewayId = g.Id 
                    INNER JOIN ControllerType ct ON c.ControllerTypeId = ct.Id;";

        public void Write()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(QueryString, connection);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("\t{0}\t{1}\t{2}", reader[0], reader["ControllerTypeName"]);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
