namespace Cube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRaitnigMig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UsersRaitings", "UserRaitingId", "dbo.Users");
            DropIndex("dbo.UsersRaitings", new[] { "UserRaitingId" });
            DropPrimaryKey("dbo.UsersRaitings");
            AddColumn("dbo.UsersRaitings", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UsersRaitings", "UserRaitingId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UsersRaitings", "UserRaitingId");
            CreateIndex("dbo.UsersRaitings", "UserId");
            AddForeignKey("dbo.UsersRaitings", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersRaitings", "UserId", "dbo.Users");
            DropIndex("dbo.UsersRaitings", new[] { "UserId" });
            DropPrimaryKey("dbo.UsersRaitings");
            AlterColumn("dbo.UsersRaitings", "UserRaitingId", c => c.Int(nullable: false));
            DropColumn("dbo.UsersRaitings", "UserId");
            AddPrimaryKey("dbo.UsersRaitings", "UserRaitingId");
            CreateIndex("dbo.UsersRaitings", "UserRaitingId");
            AddForeignKey("dbo.UsersRaitings", "UserRaitingId", "dbo.Users", "UserId");
        }
    }
}
