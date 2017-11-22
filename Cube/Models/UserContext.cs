using System.Data.Entity;
using Cube.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Cube.Models {
    public class UserContext : DbContext {
        public UserContext() : base("UserContext") {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Configuration>());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersRaiting> UsersRaitings { get; set; }
    }
}
