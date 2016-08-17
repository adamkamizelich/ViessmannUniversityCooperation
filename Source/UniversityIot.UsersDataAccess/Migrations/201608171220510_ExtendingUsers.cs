namespace UniversityIot.UsersDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendingUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        CustomerNumber = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserInstallations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        InstallationId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInstallations", "User_Id", "dbo.Users");
            DropIndex("dbo.UserInstallations", new[] { "User_Id" });
            DropTable("dbo.UserInstallations");
            DropTable("dbo.Users");
        }
    }
}
