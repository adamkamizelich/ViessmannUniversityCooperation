namespace UniversityIot.UsersDataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ExtendingUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInstallations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstallationId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Users", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInstallations", "User_Id", "dbo.Users");
            DropIndex("dbo.UserInstallations", new[] { "User_Id" });
            DropColumn("dbo.Users", "Password");
            DropTable("dbo.UserInstallations");
        }
    }
}
