using System;
using System.Security.Claims;
using Cube.Models;

namespace Cube {
    public static class SecurityService {
        public static ClaimsIdentity CreateUserIdentity(long userId, UserModel user, string authenticationType) {
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.UserRole.ToString()),
                new Claim("CreatedOn", DateTime.UtcNow.ToString("u"))
            };

            var identity = new ClaimsIdentity(claims);

            return identity;
        }
    }
}
