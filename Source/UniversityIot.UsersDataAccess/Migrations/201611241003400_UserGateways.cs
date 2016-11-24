namespace UniversityIot.UsersDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGateways : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGateways",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GatewaySerial = c.String(),
                        AccessType = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGateways", "User_Id", "dbo.Users");
            DropIndex("dbo.UserGateways", new[] { "User_Id" });
            DropTable("dbo.UserGateways");
        }
    }
}
