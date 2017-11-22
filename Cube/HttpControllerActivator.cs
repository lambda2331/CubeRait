using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace Cube {
    public class HttpControllerActivator : IHttpControllerActivator {
        private readonly IWindsorContainer m_container;

        public HttpControllerActivator(IWindsorContainer container) {
            this.m_container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType) {
            return (IHttpController)this.m_container.Resolve(controllerType);
        }
    }
}
