namespace Cube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRoleMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserRole", c => c.Byte(nullable: false, defaultValue: 1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserRole");
        }
    }
}
