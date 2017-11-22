using System.Security.Cryptography;
using System.Text;

namespace Cube {
    public static class SecurityProvider {
        public static string GetHashPassword(string password) {
            var bytes = Encoding.Unicode.GetBytes(password);
            var CSP = new MD5CryptoServiceProvider();
            var hashByte = CSP.ComputeHash(bytes);
            var hashPassword = string.Empty;
            foreach(var b in hashByte) hashPassword += string.Format("{0:x2}", b);
            return hashPassword;
        }
    }
}
