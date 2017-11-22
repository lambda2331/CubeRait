using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Cube.Models;

namespace Cube {
    public class AuthRepository : IDisposable, IAuthRepository {
        private readonly UserContext m_ctx;

        public AuthRepository(UserContext context) {
            this.m_ctx = context;
        }
        public async Task<User> RegisterUserAsync(RegisterUserModel userModel) {
            var user = new User {
                FirstName = userModel.FirstName,
                SecondName = userModel.SecondName,
                Login = userModel.UserName,
                UserRole = Role.User,
                Password = SecurityProvider.GetHashPassword(userModel.Password)
            };
            using(var ct = new UserContext()) {
                ct.Users.Add(user);
                await ct.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> FindUserAsync(string userName, string password) {
            password = SecurityProvider.GetHashPassword(password);
            var user = await this.m_ctx.Users.FirstOrDefaultAsync(
                u => u.Login.Equals(userName, StringComparison.OrdinalIgnoreCase) &&
                     u.Password.Equals(password, StringComparison.OrdinalIgnoreCase)
            );
            return user;
        }

        public UserContext GetAll() {
            return this.m_ctx;
        }

        public void Dispose() {
            this.m_ctx.Dispose();
        }
    }
}
