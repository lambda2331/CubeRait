namespace Cube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Login", c => c.String());
            DropColumn("dbo.Users", "Password");
            //this.Sql("INSERT INTO dbo.Users (Email, Name, Surname, Country, Password, UserRole) VALUES ('admin', 'admin', 'admin', 'USA', 'admin', '2')");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "Login");
        }
    }
}
