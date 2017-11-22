using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.UI;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cube;
using Cube.App_Start;
using Cube.Models;
using Cube.Plumbing;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly : OwinStartup(typeof(Startup))]

namespace Cube {

    public class Startup {

        private static readonly IWindsorContainer s_container = new WindsorContainer();
        public void Configuration(IAppBuilder app) {
            var config = new HttpConfiguration();
            this.ConfigurationOAuth(app);
            WebApiConfig.Register(config);
            CastleConfig.Config(s_container, config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseStageMarker(PipelineStage.Authenticate);
            app.UseWebApi(config);
        }

        public void ConfigurationOAuth(IAppBuilder app) {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider(),
                AccessTokenFormat =
                    new CustomJwtFormat(ConfigurationManager.AppSettings["AuthIssuer"],
                        ConfigurationManager.AppSettings["AuthAudience"],
                        ConfigurationManager.AppSettings["AuthSecret"])
            };
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            var issuer = ConfigurationManager.AppSettings["AuthIssuer"];
            var audienceId = ConfigurationManager.AppSettings["AuthAudience"];
            var audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AuthSecret"]);
            var jwtAuthOptions = new JwtBearerAuthenticationOptions {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audienceId },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[] {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                }
            };
            app.UseJwtBearerAuthentication(jwtAuthOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
