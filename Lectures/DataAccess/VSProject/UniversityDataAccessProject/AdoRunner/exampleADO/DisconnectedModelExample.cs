namespace AdoDataAccessLayer.exampleADO
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class DisconnectedModelExample
    {
        private const string ConnectionString = "Data Source=FUE003W1602\\SQLSERVER;Initial Catalog=University; Integrated Security=true";

        private const string QueryString = @"SELECT g.Name as GatewayName, ct.Name as ControllerTypeName 
                FROM Controller c 
                    INNER JOIN Gateway g ON c.GatewayId = g.Id 
                    INNER JOIN ControllerType ct ON c.ControllerTypeId = ct.Id;";

        public void Read()
        {
            DataSet queryDataSet = new DataSet();

            using (SqlDataAdapter adapter = new SqlDataAdapter(QueryString, ConnectionString))
            {
                // opens and closes connection
                adapter.Fill(queryDataSet, "Gateways");
            }

            foreach (DataRow row in queryDataSet.Tables["Gateways"].Select("GatewayName = 'MyInstallation'"))
            {
                Console.WriteLine("Gateway: {0}\t ControllerType: {1}", row[0], row["ControllerTypeName"]);
            }

            Console.WriteLine();

            // linq to dataset
            queryDataSet.Tables["Gateways"].AsEnumerable()
                .Where(x => x.Field<string>("GatewayName") == "MyInstallation")
                .Select(x => x.Field<string>("ControllerTypeName"))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
