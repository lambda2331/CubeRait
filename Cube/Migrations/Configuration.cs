using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Cube.Models;

namespace Cube.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<UserContext> {
        public Configuration() {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserContext context) {
            var hashPassword = SecurityProvider.GetHashPassword("admin");
            if(context.Users.FirstOrDefault(u =>
                   u.Login.Equals("admin", StringComparison.OrdinalIgnoreCase) &&
                   u.Password.Equals(hashPassword, StringComparison.OrdinalIgnoreCase)) != null) return;
            context.Users.Add(new User {
                FirstName = "admin",
                SecondName = "admin",
                Login = "admin",
                Password = SecurityProvider.GetHashPassword("admin"),
                UserRole = Role.Admin
            });
            context.SaveChanges();
        }
    }
}
