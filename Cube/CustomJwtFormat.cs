using System;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace Cube {
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket> {
        private readonly string m_audience;
        private readonly string m_issuer;
        private readonly byte[] m_secret;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="issuer">Issuer URL</param>
        /// <param name="audience">Audience URL</param>
        /// <param name="secret">Base64-encoded signature</param>
        public CustomJwtFormat(string issuer, string audience, string secret) {
            this.m_issuer = issuer;
            this.m_audience = audience;
            this.m_secret = TextEncodings.Base64Url.Decode(secret);
        }

        /// <summary>
        ///     Encode JWT Token
        /// </summary>
        /// <param name="data">Authentication Ticket data</param>
        /// <returns></returns>
        public string Protect(AuthenticationTicket data) {
            if(data == null) throw new ArgumentNullException(nameof(data));

            var issued = data.Properties.IssuedUtc ?? DateTime.UtcNow;

            var expires = data.Properties.ExpiresUtc ?? DateTime.UtcNow.AddHours(10);

            var signingKey = new SigningCredentials(new InMemorySymmetricSecurityKey(this.m_secret),
                "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                "http://www.w3.org/2001/04/xmlenc#sha256");
            //signingKey 
            var token = new JwtSecurityToken(this.m_issuer, this.m_audience, data.Identity.Claims, issued.UtcDateTime, expires.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        /// <summary>
        ///     Unprotect - Not Supported
        /// </summary>
        /// <param name="protectedText"></param>
        /// <returns></returns>
        public AuthenticationTicket Unprotect(string protectedText) {
            throw new NotSupportedException();
        }
    }
}
