namespace UniversityIot.GatewaysDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendingGatewaySettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gateways",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        SerialNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GatewaySettings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        HexAdress = c.String(),
                        DataType = c.Int(nullable: false),
                        IsReadonly = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GatewaySettings");
            DropTable("dbo.Gateways");
        }
    }
}
