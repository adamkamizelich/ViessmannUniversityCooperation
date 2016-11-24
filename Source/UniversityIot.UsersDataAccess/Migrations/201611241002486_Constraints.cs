namespace UniversityIot.UsersDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Constraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "CustomerNumber", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CustomerNumber", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
