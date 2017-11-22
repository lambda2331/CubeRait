namespace Cube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCountryMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Country");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Country", c => c.String());
        }
    }
}
