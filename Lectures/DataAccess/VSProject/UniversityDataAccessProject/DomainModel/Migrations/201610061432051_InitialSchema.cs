namespace DomainModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Controllers",
                c => new
                    {
                        ControllerKey = c.Int(nullable: false, identity: true),
                        Serial = c.String(maxLength: 20),
                        GatewayId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ControllerTypeKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ControllerKey)
                .ForeignKey("dbo.ControllerTypes", t => t.ControllerTypeKey, cascadeDelete: true)
                .ForeignKey("dbo.Gateways", t => t.GatewayId, cascadeDelete: true)
                .Index(t => t.GatewayId)
                .Index(t => t.ControllerTypeKey);
            
            CreateTable(
                "dbo.ControllerTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.Int(nullable: false),
                        HardwareIndex = c.Int(nullable: false),
                        SoftwareIndexMin = c.Int(nullable: false),
                        SoftwareIndexMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Datapoints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HexAddress = c.String(maxLength: 4),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gateways",
                c => new
                    {
                        GatewayId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Address = c.String(maxLength: 100),
                        Serial = c.String(maxLength: 20),
                        Type = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.GatewayId);
            
            CreateTable(
                "dbo.ControllerTypeToDatapoint",
                c => new
                    {
                        ControllerTypeId = c.Int(nullable: false),
                        DatapointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ControllerTypeId, t.DatapointId })
                .ForeignKey("dbo.ControllerTypes", t => t.ControllerTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Datapoints", t => t.DatapointId, cascadeDelete: true)
                .Index(t => t.ControllerTypeId)
                .Index(t => t.DatapointId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Controllers", "GatewayId", "dbo.Gateways");
            DropForeignKey("dbo.Controllers", "ControllerTypeKey", "dbo.ControllerTypes");
            DropForeignKey("dbo.ControllerTypeToDatapoint", "DatapointId", "dbo.Datapoints");
            DropForeignKey("dbo.ControllerTypeToDatapoint", "ControllerTypeId", "dbo.ControllerTypes");
            DropIndex("dbo.ControllerTypeToDatapoint", new[] { "DatapointId" });
            DropIndex("dbo.ControllerTypeToDatapoint", new[] { "ControllerTypeId" });
            DropIndex("dbo.Controllers", new[] { "ControllerTypeKey" });
            DropIndex("dbo.Controllers", new[] { "GatewayId" });
            DropTable("dbo.ControllerTypeToDatapoint");
            DropTable("dbo.Gateways");
            DropTable("dbo.Datapoints");
            DropTable("dbo.ControllerTypes");
            DropTable("dbo.Controllers");
        }
    }
}
