using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cube.App_Start;
using Cube.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace Cube {
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider {
        /// <inheritdoc />
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context) {
            await Task.FromResult(context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context) {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            var ctx = new UserContext();
            var repo = new AuthRepository(ctx);
                var user = await repo.FindUserAsync(context.UserName, context.Password);
                if(user == null) {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                var oAuthIdentity = SecurityService.CreateUserIdentity(user.UserId, AutoMapperConfig.GetMapper().Map<User, UserModel>(user), "JWT");
                var ticket =
                    new AuthenticationTicket(oAuthIdentity, null);
                context.Validated(ticket);
            
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context) {
            foreach(var property in context.Properties.Dictionary) context.AdditionalResponseParameters.Add(property.Key, property.Value);

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName, string login) {
            IDictionary<string, string>
                data = new Dictionary<string, string> {
                    { "userName", userName },
                    { "login", login }
                };
            return new AuthenticationProperties(data);
        }
    }
}
