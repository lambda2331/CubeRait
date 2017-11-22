using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Validation.Providers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Cube.Models;

namespace Cube.App_Start {
    public class CastleConfig : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(Component.For<UserContext>().LifestylePerWebRequest());
            container.Register(Component.For<IAuthRepository>().ImplementedBy<AuthRepository>().LifestylePerWebRequest());
            container.Register(Classes.FromThisAssembly().BasedOn<IHttpController>().LifestylePerWebRequest());
        }

        public static void Config(IWindsorContainer container, HttpConfiguration config) {
            if(container == null) throw new ArgumentNullException("container");
            container.Install(new CastleConfig());

            IHttpControllerActivator controllerFactory = new WindsorControllerActivator(container);

            if(config != null) {
                config.Services.Replace(typeof(IHttpControllerActivator), controllerFactory);
                
                var dependencyResolver = new WindsorDependencyResolver(container);
                config.DependencyResolver = dependencyResolver;
            }
        }
    }
}
