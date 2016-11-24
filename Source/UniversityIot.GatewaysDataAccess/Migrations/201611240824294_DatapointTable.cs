namespace UniversityIot.GatewaysDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatapointTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GatewaySettings", newName: "Datapoints");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Datapoints", newName: "GatewaySettings");
        }
    }
}
