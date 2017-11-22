namespace Cube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMigrationChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "SecondName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "SecondName", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 100));
        }
    }
}
