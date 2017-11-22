namespace Cube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChekedUserMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Country = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UsersRaitings",
                c => new
                    {
                        UserRaitingId = c.Int(nullable: false),
                        TypeOfCube = c.Int(nullable: false),
                        Time = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.UserRaitingId)
                .ForeignKey("dbo.Users", t => t.UserRaitingId)
                .Index(t => t.UserRaitingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersRaitings", "UserRaitingId", "dbo.Users");
            DropIndex("dbo.UsersRaitings", new[] { "UserRaitingId" });
            DropTable("dbo.UsersRaitings");
            DropTable("dbo.Users");
        }
    }
}
